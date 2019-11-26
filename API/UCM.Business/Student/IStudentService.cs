using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UCM.Business.Generics;
using UCM.Business.Student.Models;

namespace UCM.Business.Student
{
    public interface IStudentService :
        IDetailsService<StudentDetailsModel>,
        ICreateService<StudentCreateModel>
    {
        Task<StudentDetailsModel> GetStudentByPersonId(Guid id, params string[] includes);


        Task<Guid> Confirmation(StudentConfirmationModel studentConfirmationModel);
        Task<IEnumerable<Guid>> SetStudentsGroup(IEnumerable<StudentConfirmationModel> studentConfirmationModels);

        Task<IEnumerable<StudentConfirmedDetailsModel>> GetAllConfirmedAsync(params string[] includes);
        Task<IEnumerable<StudentConfirmedDetailsModel>> GetAllUnconfirmedAsync(params string[] includes);
        Task<StudentConfirmedDetailsModel> GetWithHostelById(Guid id, params string[] includes);
    }
}
