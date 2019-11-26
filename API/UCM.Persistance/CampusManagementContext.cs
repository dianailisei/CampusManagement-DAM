using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using UCM.Business.Generics;
using UCM.Domain.Entities; 
namespace UCM.Persistance
{
    public sealed class CampusManagementContext : DbContext, IGenericRepository
    {
        public CampusManagementContext(DbContextOptions<CampusManagementContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        internal DbSet<Person> Persons { get; private set; }
        internal DbSet<Role> Roles { get; private set; }
        internal DbSet<Student> Students { get; private set; }
        internal DbSet<Admin> Admins { get; private set; }

        internal DbSet<Article> Articles { get; private set; }
        internal DbSet<Application> Applications { get; private set; }
        internal DbSet<HostelPreference> HostelPreferences { get; private set; }
        internal DbSet<Hostel> Hostels { get; private set; }
        internal DbSet<HostelStatus> HostelsStatus { get; private set; }
        internal DbSet<StudentsGroup> StudentsGroups { get; private set; }
        internal DbSet<Stage> Stages { get; private set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PersonRole>().HasKey(pr => new { pr.PersonId, pr.RoleId });
        }

        private IQueryable<T> SetIncludes<T>(params string[] includes) where T : Entity
        {
            var query = Set<T>().AsQueryable();

            if (includes.Length == 0)
                return query;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        private IQueryable<T> SetPagination<T>(int pageNumber = 1, int pageSize = int.MaxValue, IQueryable<T> source = null)
            where T : Entity
        {
            var query = source ?? Set<T>().AsQueryable();

            if (pageNumber <= 0 || pageSize <= 0)
            {
                pageNumber = 1;
                pageSize = int.MaxValue;
            }

            return query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
        }

        private IQueryable<T> SetSort<T>(Func<T, object> predicate, IQueryable<T> source) where T : Entity
        {
            return source.OrderBy(predicate).AsQueryable();
        }

        public async Task<T> GetAsync<T>(Guid id, params string[] includes) where T : Entity
        {
            var query = SetIncludes<T>(includes);

            return await query.FirstOrDefaultAsync(t => t.Id == id && t.IsAvailable);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(params string[] includes) where T : Entity
        {
            var query = SetIncludes<T>(includes);

            query = query.Where(t => t.IsAvailable);

            // query = SetSort(predicate, query);

            // query = SetPagination(pagination.PageNumber, pagination.PageSize, query);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, params string[] includes) where T : Entity
        {
            var query = SetIncludes<T>(includes);

            var result = query.Where(t => t.IsAvailable).Where(predicate).ToList();
            return result;
        }

        public async Task<Guid> AddAsync<T>(T entity) where T : Entity
        {
            await Set<T>().AddAsync(entity);
            return entity.Id;
        }

        public async Task<IEnumerable<Guid>> AddAsync<T>(IEnumerable<T> entites) where T : Entity
        {
            await Set<T>().AddRangeAsync(entites);
            return entites.Select(t => t.Id).ToList();
        }

        public async Task<Guid> UpdateAsync<T>(T entity, params string[] includes) where T : Entity
        {
            var exist = await GetAsync<T>(entity.Id, includes);
            if (exist != null)
            {
                Entry(exist).CurrentValues.SetValues(entity);

                return entity.Id;
            }
            return Guid.Empty;
        }

        public async Task DeleteAsync<T>(Guid id) where T : Entity
        {
            var entity = await GetAsync<T>(id);
            if (entity != null)
            {
                entity.Delete();
                Entry(entity).CurrentValues.SetValues(entity);
            }
        }

        public async Task DeleteAsync<T>(IEnumerable<Guid> ids) where T : Entity
        {
            foreach (var id in ids)
                await DeleteAsync<T>(id);
        }

        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }

    }
}
