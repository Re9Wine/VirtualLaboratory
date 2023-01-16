using VirtualLaboratory.Domain.ApiModels.ProcessInPhenomenon;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IProcessInPhenomenonService : IBaseService<
        ProcessInPhenomenon,
        AddProcessInPhenomenonModel,
        UpdateProcessInPhenomenonModel
        >
    {
    }
}
