using System;
using Concepts;
using MongoDB.Driver;

namespace Read.StaffUsers.DataOwner
{
    public class DataOwnerRepository : ReadModelRepositoryForStaffUser<Models.DataOwner>,
        IDataOwnerRepository
    {
        public DataOwnerRepository(IMongoDatabase database) 
            : base(database, database.GetCollection<Models.DataOwner>("DataOwners"))
        {
        }

        public UpdateResult AddPhoneNumber(Guid staffUserId, string number)
        {
            return _collection.UpdateOne(Builders<Models.DataOwner>.Filter.Where(u => u.StaffUserId == staffUserId),
                Builders<Models.DataOwner>.Update.AddToSet(u => u.PhoneNumbers, new PhoneNumber(number)));
        }

        public UpdateResult RemovePhoneNumber(Guid staffUserId, string number)
        {
            return _collection.UpdateOne(Builders<Models.DataOwner>.Filter.Where(u => u.StaffUserId == staffUserId),
                Builders<Models.DataOwner>.Update.PullFilter(u => u.PhoneNumbers, pn => pn.Value == number));
        }
    }
}