using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read
{
    public interface IReadCollection<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task Remove(Guid id);
        Task Save(T obj);
    }
}
