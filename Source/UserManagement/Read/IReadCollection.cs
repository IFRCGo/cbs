using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read
{
    public interface IReadCollection<T>
    {
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save(T obj);
        Task SaveAsync(T obj);
    }
}
