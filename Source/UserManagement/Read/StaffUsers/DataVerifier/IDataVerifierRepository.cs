using System;
using MongoDB.Driver;

namespace Read.StaffUsers.DataVerifier
{
    public interface IDataVerifierRepository : IReadModelRepositoryForStaffUser<Models.DataVerifier>
    {
        UpdateResult AddPhoneNumber(Guid staffUserId, string number);
        UpdateResult RemovePhoneNumber(Guid staffUserId, string number);
    }
}