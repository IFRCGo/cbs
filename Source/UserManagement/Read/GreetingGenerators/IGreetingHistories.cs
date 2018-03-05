using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.GreetingGenerators
{
    public interface IGreetingHistories
    {
        GreetingHistory GetByPhoneNumber(string phoneNumber);
        Task<GreetingHistory> GetByPhoneNumberAsync(string phoneNumber);

        void Remove(string phoneNumber);
        Task RemoveAsync(string phoneNumber);

        GreetingHistory GetById(Guid id);

        Task<GreetingHistory> GetByIdAsync(Guid id);
        IEnumerable<GreetingHistory> GetAll();

        Task<IEnumerable<GreetingHistory>> GetAllAsync();

        void Remove(Guid id);
        Task RemoveAsync(Guid id);

        void Save(GreetingHistory dataCollector);

        Task SaveAsync(GreetingHistory dataCollector);

    }
}