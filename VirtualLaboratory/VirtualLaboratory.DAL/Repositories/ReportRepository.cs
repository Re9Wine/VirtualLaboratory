using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.DAL.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly VirtualLaboratoryContext _dbContext;

        public ReportRepository(VirtualLaboratoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Report entity)
        {
            try
            {
                await _dbContext.Reports.AddAsync(entity);

                if (await _dbContext.SaveChangesAsync() != 0)
                {
                    return entity.Id;
                }

                return 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException("Кто-то уже обновил данные и вы работаете с устаревшими данными");
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Ошибка при добавлении данных в базу данных");
            }
        }

        public async Task<bool> DeleteAsync(Report entity)
        {
            try
            {
                _dbContext.Reports.Remove(entity);

                if (await _dbContext.SaveChangesAsync() != 0)
                {
                    return true;
                }

                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException("Кто-то уже обновил данные и вы работаете с устаревшими данными");
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Ошибка при добавлении данных в базу данных");
            }
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Reports.ToListAsync();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<Report> GetAsync(int id)
        {
            try
            {
                return await _dbContext.Reports.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<bool> UpdateAsync(Report entity)
        {
            try
            {
                _dbContext.Reports.Update(entity);

                if (await _dbContext.SaveChangesAsync() != 0)
                {
                    return true;
                }

                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException("Кто-то уже обновил данные и вы работаете с устаревшими данными");
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Ошибка при добавлении данных в базу данных");
            }
        }
    }
}
