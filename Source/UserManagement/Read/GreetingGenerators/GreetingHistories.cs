using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class GreetingHistories : ExtendedReadModelRepositoryFor<GreetingHistory>,
        IGreetingHistories
    {

        public GreetingHistories(IMongoDatabase database) 
            : base(database, database.GetCollection<GreetingHistory>("GreetingHistories"))
        {
        }

        public IEnumerable<GreetingHistory> GetAll()
        {
            return GetMany(_ => true);
        }

        public GreetingHistory GetById(Guid id)
        {
            return GetOne(d => d.Id == id);
        }

        public GreetingHistory GetByPhoneNumber(string phoneNumber)
        {
            return GetOne(d => d.PhoneNumber == phoneNumber);
        }
        public void Remove(string phoneNumber)
        {
            Delete(g => g.PhoneNumber == phoneNumber);
        }
    }
}
