using System;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.StaffUsers.Models
{
    public abstract class BaseUser : IReadModel
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }

        protected BaseUser(Guid id, string fullName, string displayName, string email, DateTimeOffset registrationDate)
        {
            Id = id;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            RegistrationDate = registrationDate;
        }
    }
}