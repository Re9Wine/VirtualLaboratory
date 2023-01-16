using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.EquipmentParametr;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class EquipmentParametrService : IEquipmentParametrService
    {
        private readonly IEquipmentParametrRepository _respotitory;

        public EquipmentParametrService(IEquipmentParametrRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddEquipmentParametrModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToEquipmentParametr());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<EquipmentParametr>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<EquipmentParametr> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateEquipmentParametrModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToEquipmentParametr(id));
        }
    }
}
