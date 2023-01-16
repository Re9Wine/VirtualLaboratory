using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.DAL.Repositories
{
    public class TheoreticalInformationForLaboratoryWorkRepository
        : ITheoreticalInformationForLaboratoryWorkRepository
    {
        private readonly VirtualLaboratoryContext _dbContext;

        public TheoreticalInformationForLaboratoryWorkRepository(VirtualLaboratoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(TheoreticalInformationForLaboratoryWork entity)
        {
            try
            {
                await _dbContext.TheoreticalInformationForLaboratoryWorks.AddAsync(entity);

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

        public async Task<bool> DeleteAsync(TheoreticalInformationForLaboratoryWork entity)
        {
            try
            {
                _dbContext.TheoreticalInformationForLaboratoryWorks.Remove(entity);

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

        public async Task<IEnumerable<TheoreticalInformationForLaboratoryWork>> GetAllAsync()
        {
            try
            {
                return await _dbContext.TheoreticalInformationForLaboratoryWorks.ToListAsync();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<TheoreticalInformationForLaboratoryWork> GetAsync(int id)
        {
            try
            {
                return await _dbContext.TheoreticalInformationForLaboratoryWorks.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<bool> UpdateAsync(TheoreticalInformationForLaboratoryWork entity)
        {
            try
            {
                _dbContext.TheoreticalInformationForLaboratoryWorks.Update(entity);

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
