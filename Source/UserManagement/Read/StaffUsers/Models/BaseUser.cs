using System;
using doLittle.Read;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.StaffUsers.Models
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Admin), typeof(DataConsumer), typeof(DataCoordinator), 
        typeof(DataOwner), typeof(DataVerifier), typeof(SystemConfigurator))]
    public abstract class BaseUser : IReadModel
    {
        [BsonId]
        public Guid StaffUserId { get; set; }
        [BsonRequired]
        public string FullName { get; set; }
        [BsonRequired]
        public string DisplayName { get; set; }
        [BsonRequired]
        public string Email { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }

        protected BaseUser(Guid staffUserId, string fullName, string displayName, string email, DateTimeOffset registrationDate)
        {
            StaffUserId = staffUserId;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            RegistrationDate = registrationDate;
        }
    }
}