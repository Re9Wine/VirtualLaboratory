﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.ApiModels.Report;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Service.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _respotitory;

        public ReportService(IReportRepository respotitory)
        {
            _respotitory = respotitory;
        }

        public async Task<int> AddAsync(AddReportModel addEntity)
        {
            return await _respotitory.AddAsync(addEntity.ToReport());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _respotitory.GetAsync(id);

            return await _respotitory.DeleteAsync(deleteEntity);
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await _respotitory.GetAllAsync();
        }

        public async Task<Report> GetAsync(int id)
        {
            return await _respotitory.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateReportModel updeteEntity)
        {
            return await _respotitory.UpdateAsync(updeteEntity.ToReport(id));
        }
    }
}
