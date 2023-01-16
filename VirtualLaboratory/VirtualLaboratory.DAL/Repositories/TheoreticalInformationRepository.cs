using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.DAL.Repositories
{
    public class TheoreticalInformationRepository : ITheoreticalInformationRepository
    {
        private readonly VirtualLaboratoryContext _dbContext;

        public TheoreticalInformationRepository(VirtualLaboratoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(TheoreticalInformation entity)
        {
            try
            {
                await _dbContext.TheoreticalInformations.AddAsync(entity);

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

        public async Task<bool> DeleteAsync(TheoreticalInformation entity)
        {
            try
            {
                _dbContext.TheoreticalInformations.Remove(entity);

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

        public async Task<IEnumerable<TheoreticalInformation>> GetAllAsync()
        {
            try
            {
                return await _dbContext.TheoreticalInformations.ToListAsync();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<TheoreticalInformation> GetAsync(int id)
        {
            try
            {
                return await _dbContext.TheoreticalInformations.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Данные отсутствуют");
            }
        }

        public async Task<bool> UpdateAsync(TheoreticalInformation entity)
        {
            try
            {
                _dbContext.TheoreticalInformations.Update(entity);

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
