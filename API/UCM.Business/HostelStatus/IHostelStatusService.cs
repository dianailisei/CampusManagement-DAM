using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCM.Business.Generics;
using UCM.Business.HostelStatus.Models;
using UCM.Business.Student.Models;

namespace UCM.Business.HostelStatus
{
    public interface IHostelStatusService:
        IDetailsService<HostelStatusDetailsModel>,
        ICreateService<HostelStatusCreateModel>
    {
        Task<Guid> AddOrUpdate(HostelStatusCreateModel hostelStatusCreateModel);
        Task<IEnumerable<Guid>> AddOrUpdate(IEnumerable<HostelStatusCreateModel> hostelStatusCreateModel);

        Task<IEnumerable<HostelStatusDetailsModel>> GetSeats();
        Task<IEnumerable<StudentConfirmedDetailsModel>> SeatsAllocationPreview();
        Task<IEnumerable<HostelStatusDetailsModel>> SeatsAllocation();
        Task PublishSeats();
    }
}
