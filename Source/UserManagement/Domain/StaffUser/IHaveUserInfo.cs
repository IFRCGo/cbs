using System;

namespace Domain.StaffUser
{
    public interface IHaveUserInfo
    {
        Guid StaffUserId { get; }
        string FullName { get; }
        string DisplayName { get; }
        string Email { get; }        
    }
}