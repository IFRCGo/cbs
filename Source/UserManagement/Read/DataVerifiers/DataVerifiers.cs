using System.Collections.Generic;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.DataVerifiers
{
    public class DataVerifiers : ExtendedReadModelRepositoryFor<DataVerifier>, IDataVerifiers
    {
        public DataVerifiers(IMongoDatabase database) : base(database)
        {
        }

        public override IMongoCollection<DataVerifier> GetCollection()
        {
            return this._database.GetCollection<DataVerifier>("DataVerifiers");
        }

        public IEnumerable<DataVerifier> GetAll()
        {
            return GetMany(_ => true);
        }
    }
}
