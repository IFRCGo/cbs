using System;
using Infrastructure.Read;
using MongoDB.Driver;

namespace Read.StaffUsers.SystemConfigurator
{
    public interface ISystemConfiguratorRepository : IExtendedReadModelRepositoryFor<Models.SystemConfigurator>
    {
        UpdateResult AddPhoneNumber(Guid staffUserId, string number);
        UpdateResult RemovePhoneNumber(Guid staffUserId, string number);

        UpdateResult AddAssignedNationalSociety(Guid staffUserId, Guid nationalSociety);
        UpdateResult RemoveAssignedNationalSociety(Guid staffUserId, Guid nationalSociety);

        
    }
}