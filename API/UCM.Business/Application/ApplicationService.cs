using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampusManagement.Business.Application.Models;
using CampusManagement.Business.Generics;
using CampusManagement.Business.HostelStatus.Models;

namespace CampusManagement.Business.Application
{
    public class ApplicationService : IApplicationService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        private readonly DetailsService<Domain.Entities.Application, ApplicationDetailsModel> _detailsService;
        private readonly CreateService<Domain.Entities.Application, ApplicationCreateModel> _createService;

        public ApplicationService(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;

            _detailsService = new DetailsService<Domain.Entities.Application, ApplicationDetailsModel>
                (genericRepository, mapper);
            _createService = new CreateService<Domain.Entities.Application, ApplicationCreateModel>
                (genericRepository, mapper);
        }

        public async Task<ApplicationDetailsModel> GetAsync(Guid id, params string[] includes)
        {
            return await _detailsService.GetAsync(id, includes);
        }

        public async Task<IEnumerable<ApplicationDetailsModel>> GetAllAsync(params string[] includes)
        {
            return await _detailsService.GetAllAsync(includes);
        }

        public async Task<Guid> AddAsync(ApplicationCreateModel entity)
        {
            var result = await _detailsService.GetAllAsync();
            var studentApplications = result.Where(a => a.StudentId == entity.StudentId).Select(a=>a.Id);

            await _createService.DeleteAsync(studentApplications);

            return await _createService.AddAsync(entity);
        }

        public async Task<IEnumerable<Guid>> AddAsync(IEnumerable<ApplicationCreateModel> entities)
        {
            return await _createService.AddAsync(entities);
        }

        public async Task<Guid> UpdateAsync(Guid id, ApplicationCreateModel entity, params string[] includes)
        {
            return await _createService.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _createService.DeleteAsync(id);
        }

        public async Task DeleteAsync(IEnumerable<Guid> ids)
        {
            await _createService.DeleteAsync(ids);
        }

        public async Task<IEnumerable<StudentsYearDistribution>> SeatsDistribution()
        {
            //var hostelStatus = await _genericRepository.GetAsync<Domain.Entities.HostelStatus>(id,"Hostel");

            var applications = await _genericRepository.GetAllAsync<Domain.Entities.Application>("Student", "Student.Person");

            var students = await _genericRepository.GetAllAsync<Domain.Entities.Student>("Person");

            IList<StudentsYearDistribution> yearDistributions = new List<StudentsYearDistribution>();

            int totalStudents = 0;
            int totalApplications = 0;

            var gender = "F";
            for (int i = 1; i <= 5; ++i)
            {
                var yearDistribution = new StudentsYearDistribution()
                {
                    Gender = gender,
                    Year = i,
                    YearStudentsNumber = students.Count(s => s.Year == i && s.Person.Gender == gender),
                    YearApplicationsNumber = applications.Count(a => a.Student.Year == i && a.Student.Person.Gender == gender)
                };
                totalStudents += yearDistribution.YearStudentsNumber;
                totalApplications += yearDistribution.YearApplicationsNumber;

                yearDistributions.Add(yearDistribution);
            }

            for (int i = 0; i < 5; ++i)
            {
                yearDistributions[i].YearStudentsPercentage =
                    (double)yearDistributions[i].YearStudentsNumber / (double)totalStudents;

                yearDistributions[i].YearApplicationsPercentage =
                    (double)yearDistributions[i].YearApplicationsNumber / (double)totalApplications;

                yearDistributions[i].YearPercentageMean =
                    (yearDistributions[i].YearStudentsPercentage + yearDistributions[i].YearApplicationsPercentage) / 2;
            }

            totalStudents = 0;
            totalApplications = 0;

            gender = "M";
            for (int i = 1; i <= 5; ++i)
            {
                var yearDistribution = new StudentsYearDistribution()
                {
                    Gender = gender,
                    Year = i,
                    YearStudentsNumber = students.Count(s => s.Year == i && s.Person.Gender == gender),
                    YearApplicationsNumber = applications.Count(a => a.Student.Year == i && a.Student.Person.Gender == gender)
                };
                totalStudents += yearDistribution.YearStudentsNumber;
                totalApplications += yearDistribution.YearApplicationsNumber;

                yearDistributions.Add(yearDistribution);
            }

            for (int i = 5; i < 10; ++i)
            {
                yearDistributions[i].YearStudentsPercentage =
                    (double)yearDistributions[i].YearStudentsNumber / (double)totalStudents;

                yearDistributions[i].YearApplicationsPercentage =
                    (double)yearDistributions[i].YearApplicationsNumber / (double)totalApplications;

                yearDistributions[i].YearPercentageMean =
                    (yearDistributions[i].YearStudentsPercentage + yearDistributions[i].YearApplicationsPercentage) / 2;
            }


            return yearDistributions;
        }
    }
}
