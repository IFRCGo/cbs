using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.GreetingGenerators
{
    public interface IGreetingHistories : IExtendedReadModelRepositoryFor<GreetingHistory>
    {
        GreetingHistory GetByPhoneNumber(string phoneNumber);

        void Remove(string phoneNumber);

        GreetingHistory GetById(Guid id);

        IEnumerable<GreetingHistory> GetAll();

    }
}