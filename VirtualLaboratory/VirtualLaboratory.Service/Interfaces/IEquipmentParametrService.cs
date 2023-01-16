using VirtualLaboratory.Domain.ApiModels.EquipmentParametr;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IEquipmentParametrService : IBaseService<
        EquipmentParametr,
        AddEquipmentParametrModel,
        UpdateEquipmentParametrModel
        >
    {
    }
}
