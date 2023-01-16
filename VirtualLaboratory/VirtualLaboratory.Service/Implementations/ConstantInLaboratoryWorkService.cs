using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.ConstantInLaboratoryWork;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class ConstantInLaboratoryWorkService : IConstantInLaboratoryWorkService
    {
        private readonly IConstantInLaboratoryWorkRepository _respotitory;

        public ConstantInLaboratoryWorkService(IConstantInLaboratoryWorkRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddConstantInLaboratoryWorkModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToConstantInLaboratoryWork());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<ConstantInLaboratoryWork>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<ConstantInLaboratoryWork> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateConstantInLaboratoryWorkModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToConstantInLaboratoryWork(id));
        }
    }
}
