using System.Collections.Generic;
using System.Threading.Tasks;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IBaseService<T, A, U>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<int> AddAsync(A addEntity);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, U updeteEntity);
    }
}
