using UCM.Business.Generics;
using UCM.Business.Hostel.Models;

namespace UCM.Business.Hostel
{
    public interface IHostelService : 
        IDetailsService<HostelDetailsModel>,
        ICreateService<HostelCreateModel>
    {
    }
}
