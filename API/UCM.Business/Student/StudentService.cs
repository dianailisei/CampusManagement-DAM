using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UCM.Business.Generics;
using UCM.Business.Helpers;
using UCM.Business.Student.Builder;
using UCM.Business.Student.Models;
using UCM.Domain.Entities;

namespace UCM.Business.Student
{
    public class StudentService :
        IStudentService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        private readonly DetailsService<Domain.Entities.Student, StudentDetailsModel> _detailsService;
        private readonly CreateService<Domain.Entities.Student, StudentCreateModel> _createService;

        public StudentService(IGenericRepository genericRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;

            _detailsService = new DetailsService<Domain.Entities.Student, StudentDetailsModel>
                (genericRepository, mapper);
            _createService = new CreateService<Domain.Entities.Student, StudentCreateModel>
                (genericRepository, mapper);
        }

        public async Task<StudentDetailsModel> GetAsync(Guid id, params string[] includes)
        {
            return await _detailsService.GetAsync(id, includes);
        }

        public async Task<IEnumerable<StudentDetailsModel>> GetAllAsync(params string[] includes)
        {
            var result = await _genericRepository.GetAllAsync<Domain.Entities.Student>(includes);

            return _mapper.Map<IEnumerable<StudentDetailsModel>>(result);
        }

        public async Task<Guid> AddAsync(StudentCreateModel entity)
        {
            var studentRolesGuid = _genericRepository.FindAsync<Role>(r => r.Name == "Student").Result.Select(p => p.Id)
                .ToList();

            StudentBuilder studentBuilder = new StudentBuilder();

            studentBuilder.SetFirstName(entity.FirstName);
            studentBuilder.SetLastName(entity.LastName);
            studentBuilder.SetEmail(entity.Email);
            studentBuilder.SetGender(entity.Gender);
            studentBuilder.SetPassword(_passwordHasher.HashPassword(entity.Password));
            studentBuilder.SetYear(entity.Year);
            studentBuilder.SetCnp(entity.Cnp);
            studentBuilder.SetNationality(entity.Nationality);
            studentBuilder.SetScore(entity.Score);
            studentBuilder.SetSecondScore(entity.SecondScore);

            var studentModel = studentBuilder.Build();

            var person = Domain.Entities.Person.Create(entity.FirstName, entity.LastName,
                entity.Email, entity.Gender, _passwordHasher.HashPassword(entity.Password), studentRolesGuid);

            
            var student = Domain.Entities.Student.Create(person, entity.Year, entity.Cnp,
                entity.Nationality, entity.Score, entity.SecondScore);

            var result = await _genericRepository.AddAsync(student);
            await _genericRepository.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<Guid>> AddAsync(IEnumerable<StudentCreateModel> entities)
        {
            IEnumerable<Guid> ids = new List<Guid>();

            foreach (var studentCreateModel in entities)
                ids.Append(await AddAsync(studentCreateModel));

            return ids;
        }

        public async Task<Guid> UpdateAsync(Guid id, StudentCreateModel entity, params string[] includes)
        {
            return await _createService.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _createService.DeleteAsync(id);
        }

        public async Task DeleteAsync(IEnumerable<Guid> idList)
        {
            await _createService.DeleteAsync(idList);
        }

        public async Task<StudentDetailsModel> GetStudentByPersonId(Guid id, params string[] includes)
        {
            var result = await _genericRepository.FindAsync<Domain.Entities.Student>(s => s.PersonId == id, includes);

            return _mapper.Map<StudentDetailsModel>(result.FirstOrDefault());
        }

        public async Task<Guid> Confirmation(StudentConfirmationModel studentConfirmationModel)
        {
            var student = await _genericRepository.GetAsync<Domain.Entities.Student>(studentConfirmationModel.Id);
            student.Confirmation(studentConfirmationModel.Confirmed, studentConfirmationModel.StudentsGroupId);

            var resullt = await _genericRepository.UpdateAsync(student);
            await _genericRepository.SaveAsync();

            return resullt;
        }

        public async Task<IEnumerable<Guid>> SetStudentsGroup(IEnumerable<StudentConfirmationModel> studentConfirmationModels)
        {
            var results = new List<Guid>();
            foreach (var studentConfirmationModel in studentConfirmationModels)
            {
                var student = await _genericRepository.GetAsync<Domain.Entities.Student>(studentConfirmationModel.Id);
                student.Confirmation(studentConfirmationModel.Confirmed, studentConfirmationModel.StudentsGroupId);
                results.Add(await _genericRepository.UpdateAsync(student));
            }

            await _genericRepository.SaveAsync();

            return results;
        }

        public async Task<IEnumerable<StudentConfirmedDetailsModel>> GetAllConfirmedAsync(params string[] includes)
        {
            var results = await _genericRepository.FindAsync<Domain.Entities.Student>(s => s.Confirmed, "StudentsGroup.HostelStatus.Hostel", "Person");
            return _mapper.Map<IEnumerable<StudentConfirmedDetailsModel>>(results);
        }

        public async Task<IEnumerable<StudentConfirmedDetailsModel>> GetAllUnconfirmedAsync(params string[] includes)
        {
            var results = await _genericRepository.FindAsync<Domain.Entities.Student>(s => s.Confirmed == false && s.StudentsGroupId != null, "StudentsGroup.HostelStatus.Hostel", "Person");
            return _mapper.Map<IEnumerable<StudentConfirmedDetailsModel>>(results);
        }

        public async Task<StudentConfirmedDetailsModel> GetWithHostelById(Guid id, params string[] includes)
        {
            var results = await _genericRepository.FindAsync<Domain.Entities.Student>(s => s.Id == id, "StudentsGroup.HostelStatus.Hostel", "Person");
            return _mapper.Map<StudentConfirmedDetailsModel>(results.FirstOrDefault());
        }
    }
}
