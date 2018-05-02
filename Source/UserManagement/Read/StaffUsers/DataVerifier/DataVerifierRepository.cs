using System;
using Concepts;
using MongoDB.Driver;

namespace Read.StaffUsers.DataVerifier
{
    public class DataVerifierRepository : ReadModelRepositoryForStaffUser<Models.DataVerifier>,
        IDataVerifierRepository
    {
        public DataVerifierRepository(IMongoDatabase database)
            : base(database, database.GetCollection<Models.DataVerifier>("DataVerifiers"))
        {
        }

        public UpdateResult AddPhoneNumber(Guid staffUserId, string number)
        {
            return _collection.UpdateOne(Builders<Models.DataVerifier>.Filter.Where(u => u.StaffUserId == staffUserId),
                Builders<Models.DataVerifier>.Update.AddToSet(u => u.PhoneNumbers, new PhoneNumber(number)));
        }

        public UpdateResult RemovePhoneNumber(Guid staffUserId, string number)
        {
            return _collection.UpdateOne(Builders<Models.DataVerifier>.Filter.Where(u => u.StaffUserId == staffUserId),
                Builders<Models.DataVerifier>.Update.PullFilter(u => u.PhoneNumbers, pn => pn.Value == number));
        }

    }
}