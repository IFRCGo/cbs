using System;

namespace Domain
{
    public interface IUserRules
    {
        bool IsUserExisting(Guid userId);
    }
}