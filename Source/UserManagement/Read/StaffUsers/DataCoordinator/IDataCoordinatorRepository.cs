using System;
using Infrastructure.Read;
using MongoDB.Driver;

namespace Read.StaffUsers.DataCoordinator
{
    public interface IDataCoordinatorRepository : IExtendedReadModelRepositoryFor<Models.DataCoordinator>
    {
        UpdateResult AddPhoneNumber(Guid staffUserId, string number);
        UpdateResult RemovePhoneNumber(Guid staffUserId, string number);

        UpdateResult AddAssignedNationalSociety(Guid staffUserId, Guid nationalSociety);
        UpdateResult RemoveAssignedNationalSociety(Guid staffUserId, Guid nationalSociety);
    }
}