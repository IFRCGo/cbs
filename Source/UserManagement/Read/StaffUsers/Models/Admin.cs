using System;

namespace Read.StaffUsers.Models
{
    public class Admin : BaseUser
    {
        public Admin(Guid id, string fullName, string displayName, 
            string email, DateTimeOffset registrationDate) 
            : base(id, fullName, displayName, email, registrationDate)
        {
        }
    }
}