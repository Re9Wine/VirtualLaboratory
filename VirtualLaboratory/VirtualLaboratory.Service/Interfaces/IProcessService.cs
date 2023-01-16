using VirtualLaboratory.Domain.ApiModels.Process;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IProcessService : IBaseService<
        Process,
        AddProcessModel,
        UpdateProcessModel
        >
    {
    }
}
