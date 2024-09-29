using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Domain.Repository
{
    public interface IRepository<T>
    {
        Task CreateAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<T?> FindByIdAsync(string id);
        Task DeleteAsync(string id);
        Task<List<T>> FindAllAsync();
    }
}