using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task InsertAsync(T entity);
        Task<T> GetByIdAsync(int? id);
        Task<IEnumerable<T>> GetAll();
        Task UpdateAsync(int? id, T entity);
        Task RemoveAsync(int id);
    }
}
