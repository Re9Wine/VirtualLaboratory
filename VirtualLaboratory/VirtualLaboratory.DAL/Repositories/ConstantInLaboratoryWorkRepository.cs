using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.DAL.Repositories
{
    public class ConstantInLaboratoryWorkRepository : IConstantInLaboratoryWorkRepository
    {
        private readonly VirtualLaboratoryContext _dbContext;

        public ConstantInLaboratoryWorkRepository(VirtualLaboratoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(ConstantInLaboratoryWork entity)
        {
            try
            {
                await _dbContext.ConstantInLaboratoryWorks.AddAsync(entity);

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

        public async Task<bool> DeleteAsync(ConstantInLaboratoryWork entity)
        {
            try
            {
                _dbContext.ConstantInLaboratoryWorks.Remove(entity);

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

        public async Task<IEnumerable<ConstantInLaboratoryWork>> GetAllAsync()
        {
            try
            {
                return await _dbContext.ConstantInLaboratoryWorks.ToListAsync();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<ConstantInLaboratoryWork> GetAsync(int id)
        {
            try
            {
                return await _dbContext.ConstantInLaboratoryWorks.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<bool> UpdateAsync(ConstantInLaboratoryWork entity)
        {
            try
            {
                _dbContext.ConstantInLaboratoryWorks.Update(entity);

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
