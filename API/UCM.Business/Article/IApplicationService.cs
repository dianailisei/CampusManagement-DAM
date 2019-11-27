using System.Collections.Generic;
using System.Threading.Tasks;
using UCM.Business.Application.Models;
using UCM.Business.Generics;
using UCM.Business.HostelStatus.Models;

namespace UCM.Business.Application
{
    public interface IApplicationService:
        IDetailsService<ApplicationDetailsModel>,
        ICreateService<ApplicationCreateModel>
    {
        Task<IEnumerable<StudentsYearDistribution>> SeatsDistribution();
    }
}
