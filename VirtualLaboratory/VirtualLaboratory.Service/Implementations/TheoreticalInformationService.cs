using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.TheoreticalInformation;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class TheoreticalInformationService : ITheoreticalInformationService
    {
        private readonly ITheoreticalInformationRepository _respotitory;

        public TheoreticalInformationService(ITheoreticalInformationRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddTheoreticalInformationModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToTheoreticalInformation());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<TheoreticalInformation>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<TheoreticalInformation> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTheoreticalInformationModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToTheoreticalInformation(id));
        }
    }
}
