using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.PhenomenonInLaboratoryWork;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class PhenomenonInLaboratoryWorkService : IPhenomenonInLaboratoryWorkService
    {
        private readonly IPhenomenonInLaboratoryWorkRepository _respotitory;

        public PhenomenonInLaboratoryWorkService(IPhenomenonInLaboratoryWorkRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddPhenomenonInLaboratoryWorkModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToPhenomenonInLaboratoryWork());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<PhenomenonInLaboratoryWork>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<PhenomenonInLaboratoryWork> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdatePhenomenonInLaboratoryWorkModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToPhenomenonInLaboratoryWork(id));
        }
    }
}
