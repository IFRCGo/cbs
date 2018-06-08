using System;
using Concepts;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.StaffUsers.SystemConfigurator
{
    public class SystemConfiguratorRepository : ExtendedReadModelRepositoryFor<Models.SystemConfigurator>,
        ISystemConfiguratorRepository
    {
        public SystemConfiguratorRepository(IMongoDatabase database)
            : base(database, database.GetCollection<Models.SystemConfigurator>("SystemConfigurators"))
        {
        }
        public UpdateResult AddPhoneNumber(Guid staffUserId, string number)
        {
            return Update(u => u.Id == staffUserId,
                Builders<Models.SystemConfigurator>.Update.AddToSet(u => u.PhoneNumbers, new PhoneNumber(number)));
        }

        public UpdateResult RemovePhoneNumber(Guid staffUserId, string number)
        {
            return Update(u => u.Id == staffUserId,
                Builders<Models.SystemConfigurator>.Update.PullFilter(u => u.PhoneNumbers, pn => pn.Value == number));
        }

        public UpdateResult AddAssignedNationalSociety(Guid staffUserId, Guid nationalSociety)
        {

            return Update(u => u.Id == staffUserId,
                Builders<Models.SystemConfigurator>.Update.AddToSet(u => u.AssignedNationalSocieties, nationalSociety));
        }

        public UpdateResult RemoveAssignedNationalSociety(Guid staffUserId, Guid nationalSociety)
        {
            return Update(u => u.Id == staffUserId,
                Builders<Models.SystemConfigurator>.Update.PullFilter(u => u.AssignedNationalSocieties, ns => ns == nationalSociety));
        }
    }
}