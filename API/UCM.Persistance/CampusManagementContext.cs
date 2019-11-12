using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UCM.Domain.Entities; 
namespace UCM.Persistance
{
    public class CampusManagementContext : DbContext
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

 
    }
}
