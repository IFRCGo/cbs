using System;
using MongoDB.Driver;

namespace Read.StaffUsers.DataOwner
{
    public interface IDataOwnerRepository : IReadModelRepositoryForStaffUser<Models.DataOwner>
    {
        UpdateResult AddPhoneNumber(Guid staffUserId, string number);
        UpdateResult RemovePhoneNumber(Guid staffUserId, string number);
    }
}