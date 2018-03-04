using System;
using System.Collections.Generic;
using Concepts;

namespace Domain.StaffUser.Roles
{
    public abstract class StaffRole : IHaveUserInfo
    {
        public Guid StaffUserId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}