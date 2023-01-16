using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.Constant;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class ConstantService : IConstantService
    {
        private readonly IConstantRepository _respotitory;

        public ConstantService(IConstantRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddConstantModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToConstant());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<Constant>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<Constant> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateConstantModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToConstant(id));
        }
    }
}
