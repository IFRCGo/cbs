using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.StaffUsers
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Admin), typeof(DataConsumer), typeof(DataCoordinator), typeof(DataOwner), typeof(DataVerifier), typeof(SystemConfigurator))]
    public abstract class BaseUser
    {
        [BsonId]
        public Guid StaffUserId { get; set; }
        [BsonRequired]
        public string FullName { get; set; }
        [BsonRequired]
        public string DisplayName { get; set; }
        [BsonRequired]
        public string Email { get; set; }
        [BsonRequired]
        public DateTimeOffset RegistrationDate { get; set; }

        public BaseUser(Guid staffUserId, string fullName, string displayName, string email, DateTimeOffset registrationDate)
        {
            StaffUserId = staffUserId;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            RegistrationDate = registrationDate;
        }
    }
}