using VirtualLaboratory.Domain.ApiModels.EquipmentParametr;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IEquipmentParametrServise : IBaseService<
        EquipmentParametr,
        AddEquipmentParametrModel,
        UpdateEquipmentParametrModel
        >
    {
    }
}
