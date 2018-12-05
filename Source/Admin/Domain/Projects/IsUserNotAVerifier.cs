using System;

namespace Domain.Projects
{
    public delegate bool IsUserNotAVerifier(Guid projectId, Guid userId);
}
