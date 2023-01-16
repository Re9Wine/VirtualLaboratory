using VirtualLaboratory.Domain.ApiModels.Phenomenon;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IPhenomenonService : IBaseService<
        Phenomenon,
        AddPhenomenonModel,
        UpdatePhenomenonModel
        >
    {
    }
}
