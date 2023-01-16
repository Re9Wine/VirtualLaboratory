using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.Installation;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class InstallationService : IInstallationService
    {
        private readonly IInstallationRepository _respotitory;

        public InstallationService(IInstallationRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddInstallationModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToInstallation());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<Installation>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<Installation> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateInstallationModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToInstallation(id));
        }
    }
}
