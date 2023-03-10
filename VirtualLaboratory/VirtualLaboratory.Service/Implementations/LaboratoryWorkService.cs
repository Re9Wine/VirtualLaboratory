using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.LaboratoryWork;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class LaboratoryWorkService : ILaboratoryWorkService
    {
        private readonly ILaboratoryWorkRepository _respotitory;

        public LaboratoryWorkService(ILaboratoryWorkRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddLaboratoryWorkModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToLaboratoryWork());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<LaboratoryWork>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<LaboratoryWork> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateLaboratoryWorkModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToLaboratoryWork(id));
        }
    }
}
