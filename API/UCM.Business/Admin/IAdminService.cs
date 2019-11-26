using System;
using System.Threading.Tasks;
using UCM.Business.Generics;
using UCM.Business.Admin.Models;

namespace UCM.Business.Admin
{
    public interface IAdminService : 
        IDetailsService<AdminDetailsModel>,
        ICreateService<AdminCreateModel>
    {
        Task<AdminDetailsModel> GetAdminByPersonId(Guid id, params string[] includes);
    }
}
