using System;
using MongoDB.Driver;

namespace Read.StaffUsers.DataCoordinator
{
    public interface IDataCoordinatorRepository : IReadModelRepositoryForStaffUser<Models.DataCoordinator>
    {
        UpdateResult AddPhoneNumber(Guid staffUserId, string number);
        UpdateResult RemovePhoneNumber(Guid staffUserId, string number);

        UpdateResult AddAssignedNationalSociety(Guid staffUserId, Guid nationalSociety);
        UpdateResult RemoveAssignedNationalSociety(Guid staffUserId, Guid nationalSociety);
    }
}