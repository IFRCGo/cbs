using System;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.StaffUsers.Models
{
    public abstract class BaseUser : IReadModel
    {
        public Guid StaffUserId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
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
    //TODO: We can migrate from having this custom ClassMap. Delete this ClassMap and change IdMember field's name to Id.
    // important that that change also is reflected in Frontend
    public class BaseUserClassMap : IMongoDbClassMapFor<BaseUser>
    {
        public void Map(BsonClassMap<BaseUser> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(g => g.StaffUserId);
        }

        public void Register()
        {
            BsonClassMap.RegisterClassMap<BaseUser>(Map);
        }

        public bool IsRegistered()
        {
            return BsonClassMap.IsClassMapRegistered(typeof(BaseUser));
        }
    }
}