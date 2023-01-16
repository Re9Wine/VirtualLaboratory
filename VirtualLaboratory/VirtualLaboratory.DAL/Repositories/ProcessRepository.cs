using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.DAL.Repositories
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly VirtualLaboratoryContext _dbContext;

        public ProcessRepository(VirtualLaboratoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Process entity)
        {
            try
            {
                await _dbContext.Processes.AddAsync(entity);

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

        public async Task<bool> DeleteAsync(Process entity)
        {
            try
            {
                _dbContext.Processes.Remove(entity);

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

        public async Task<IEnumerable<Process>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Processes.ToListAsync();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<Process> GetAsync(int id)
        {
            try
            {
                return await _dbContext.Processes.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<bool> UpdateAsync(Process entity)
        {
            try
            {
                _dbContext.Processes.Update(entity);

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
