using VirtualLaboratory.Domain.ApiModels.Constant;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IConstantService : IBaseService<
        Constant,
        AddConstantModel,
        UpdateConstantModel
        >
    {
    }
}
