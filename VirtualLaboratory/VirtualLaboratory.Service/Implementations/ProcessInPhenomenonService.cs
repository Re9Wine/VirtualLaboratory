using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.ProcessInPhenomenon;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class ProcessInPhenomenonService : IProcessInPhenomenonService
    {
        private readonly IProcessInPhenomenonRepository _respotitory;

        public ProcessInPhenomenonService(IProcessInPhenomenonRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddProcessInPhenomenonModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToProcessInPhenomenon());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<ProcessInPhenomenon>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<ProcessInPhenomenon> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateProcessInPhenomenonModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToProcessInPhenomenon(id));
        }
    }
}
