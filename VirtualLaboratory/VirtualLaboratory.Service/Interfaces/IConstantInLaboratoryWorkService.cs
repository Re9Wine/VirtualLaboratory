using VirtualLaboratory.Domain.ApiModels.ConstantInLaboratoryWork;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IConstantInLaboratoryWorkService : IBaseService<
        ConstantInLaboratoryWork,
        AddConstantInLaboratoryWorkModel,
        UpdateConstantInLaboratoryWorkModel
        >
    {
    }
}
