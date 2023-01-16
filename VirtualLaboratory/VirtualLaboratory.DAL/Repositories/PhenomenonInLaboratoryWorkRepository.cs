using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.DAL.Repositories
{
    public class PhenomenonInLaboratoryWorkRepository : IPhenomenonInLaboratoryWorkRepository
    {
        private readonly VirtualLaboratoryContext _dbContext;

        public PhenomenonInLaboratoryWorkRepository(VirtualLaboratoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(PhenomenonInLaboratoryWork entity)
        {
            try
            {
                await _dbContext.PhenomenonInLaboratoryWorks.AddAsync(entity);

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

        public async Task<bool> DeleteAsync(PhenomenonInLaboratoryWork entity)
        {
            try
            {
                _dbContext.PhenomenonInLaboratoryWorks.Remove(entity);

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

        public async Task<IEnumerable<PhenomenonInLaboratoryWork>> GetAllAsync()
        {
            try
            {
                return await _dbContext.PhenomenonInLaboratoryWorks.ToListAsync();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<PhenomenonInLaboratoryWork> GetAsync(int id)
        {
            try
            {
                return await _dbContext.PhenomenonInLaboratoryWorks.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<bool> UpdateAsync(PhenomenonInLaboratoryWork entity)
        {
            try
            {
                _dbContext.PhenomenonInLaboratoryWorks.Update(entity);

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
