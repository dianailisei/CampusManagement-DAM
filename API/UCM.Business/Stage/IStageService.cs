using UCM.Business.Generics;
using UCM.Business.Stage.Models;
using System.Threading.Tasks;

namespace UCM.Business.Stage
{
    public interface IStageService : IDetailsService<StageDetailsModel>,
        ICreateService<StageCreateModel>
    {
        Task<StageDetailsModel> GetLastStage(params string[] includes);
    }
}
