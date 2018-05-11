using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read;

namespace Read.GreetingGenerators
{
    public interface IGreetingHistories : IExtendedReadModelRepositoryFor<GreetingHistory>
    {
        GreetingHistory GetByPhoneNumber(string phoneNumber);
        Task<GreetingHistory> GetByPhoneNumberAsync(string phoneNumber);

        void Remove(string phoneNumber);
        Task RemoveAsync(string phoneNumber);

        GreetingHistory GetById(Guid id);

        Task<GreetingHistory> GetByIdAsync(Guid id);
        IEnumerable<GreetingHistory> GetAll();

        Task<IEnumerable<GreetingHistory>> GetAllAsync();
    }
}