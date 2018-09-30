using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Projects
{
    public delegate bool IsUserNotAVerifier(Guid projectId, Guid userId);
}
