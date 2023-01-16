using VirtualLaboratory.Domain.ApiModels.Equipment;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IEquipmentService : IBaseService<
        Equipment,
        AddEquipmentModel,
        UpdateEquipmentModel
        >
    {
    }
}
