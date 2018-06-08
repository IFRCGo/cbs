using System;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.StaffUsers.DataOwner
{
    public interface IDataOwnerRepository : IExtendedReadModelRepositoryFor<Models.DataOwner>
    {
        UpdateResult AddPhoneNumber(Guid staffUserId, string number);
        UpdateResult RemovePhoneNumber(Guid staffUserId, string number);
    }
}