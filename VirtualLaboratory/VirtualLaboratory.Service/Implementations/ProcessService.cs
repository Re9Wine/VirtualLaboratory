using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.Process;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _respotitory;

        public ProcessService(IProcessRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddProcessModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToProcess());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<Process>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<Process> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateProcessModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToProcess(id));
        }
    }
}
