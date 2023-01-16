using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.TheoreticalInformationForLaboratoryWork;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class TheoreticalInformationForLaboratoryWorkService : ITheoreticalInformationForLaboratoryWorkService
    {
        private readonly ITheoreticalInformationForLaboratoryWorkRepository _respotitory;

        public TheoreticalInformationForLaboratoryWorkService(ITheoreticalInformationForLaboratoryWorkRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddTheoreticalInformationForLaboratoryWorkModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToTheoreticalInformationForLaboratoryWork());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<TheoreticalInformationForLaboratoryWork>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<TheoreticalInformationForLaboratoryWork> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTheoreticalInformationForLaboratoryWorkModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToTheoreticalInformationForLaboratoryWork(id));
        }
    }
}
