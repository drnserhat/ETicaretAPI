using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T data);
        Task<bool> AddRangeAsync(List<T> data);
        bool Remove(T data);
        bool RemoveRange(List<T> data);
        Task<bool> RemoveAsync(string id);
        bool Update(T data);
        Task<int> SaveAsync();
    }
}
