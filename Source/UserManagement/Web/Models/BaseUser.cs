using System;

namespace Web.Models
{
    public abstract class BaseUser
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
}