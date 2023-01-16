using VirtualLaboratory.Domain.ApiModels.LaboratoryWork;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface ILaboratoryWorkService : IBaseService<
        LaboratoryWork,
        AddLaboratoryWorkModel,
        UpdateLaboratoryWorkModel
        >
    {
    }
}
