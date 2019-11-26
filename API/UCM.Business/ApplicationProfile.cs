using UCM.Business.Person.Models;
using UCM.Business.Student.Models;

namespace UCM.Business
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Domain.Entities.Person, PersonDetailsModel>();

            CreateMap<Domain.Entities.Student, StudentDetailsModel>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.Person.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.Person.LastName))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Person.Email))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Person.Gender));

            CreateMap<Domain.Entities.Student, StudentConfirmedDetailsModel>()
                .ForMember(d => d.HostelName, opt => opt.MapFrom(s => s.StudentsGroup.HostelStatus.Hostel.Name)).ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.Person.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.Person.LastName))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Person.Email))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Person.Gender));

            CreateMap<StudentCreateModel, Domain.Entities.Student>();
            CreateMap<StudentDetailsModel, StudentConfirmedDetailsModel>();
        }
    }
}