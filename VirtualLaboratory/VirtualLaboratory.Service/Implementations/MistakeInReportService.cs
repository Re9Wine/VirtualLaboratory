using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.MistakeInReport;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class MistakeInReportService : IMistakeInReportService
    {
        private readonly IMistakeInReportRepository _respotitory;

        public MistakeInReportService(IMistakeInReportRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddMistakeInReportModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToMistakeInReport());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<MistakeInReport>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<MistakeInReport> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateMistakeInReportModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToMistakeInReport(id));
        }
    }
}
