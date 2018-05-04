using System;
using MongoDB.Driver;

namespace Read.StaffUsers.SystemConfigurator
{
    public interface ISystemConfiguratorRepository : IReadModelRepositoryForStaffUser<Models.SystemConfigurator>
    {
        UpdateResult AddPhoneNumber(Guid staffUserId, string number);
        UpdateResult RemovePhoneNumber(Guid staffUserId, string number);

        UpdateResult AddAssignedNationalSociety(Guid staffUserId, Guid nationalSociety);
        UpdateResult RemoveAssignedNationalSociety(Guid staffUserId, Guid nationalSociety);

        
    }
}