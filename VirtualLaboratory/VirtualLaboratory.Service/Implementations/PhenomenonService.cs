using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.Phenomenon;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class PhenomenonService : IPhenomenonService
    {
        private readonly IPhenomenonRepository _respotitory;

        public PhenomenonService(IPhenomenonRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddPhenomenonModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToPhenomenon());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<Phenomenon>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<Phenomenon> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdatePhenomenonModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToPhenomenon(id));
        }
    }
}
