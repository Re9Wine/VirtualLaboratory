using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.Equipment;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _respotitory;

        public EquipmentService(IEquipmentRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddEquipmentModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToEquipment());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<Equipment> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateEquipmentModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToEquipment(id));
        }
    }
}
