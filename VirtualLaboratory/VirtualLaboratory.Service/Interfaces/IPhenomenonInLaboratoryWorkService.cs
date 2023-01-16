using VirtualLaboratory.Domain.ApiModels.PhenomenonInLaboratoryWork;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IPhenomenonInLaboratoryWorkService : IBaseService<
        PhenomenonInLaboratoryWork,
        AddPhenomenonInLaboratoryWorkModel,
        UpdatePhenomenonInLaboratoryWorkModel
        >
    {
    }
}
