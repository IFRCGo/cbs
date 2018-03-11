using System;

namespace Read.StaffUsers.Models
{
    public class Admin : BaseUser
    {
        public Admin(Guid staffUserId, string fullName, string displayName, 
            string email, DateTimeOffset registrationDate) 
            : base(staffUserId, fullName, displayName, email, registrationDate)
        {
        }
    }
}