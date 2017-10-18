using System;

namespace Read
{
    public interface IProjectRoles
    {
        ProjectRole GetById(Guid id);
        void Save(ProjectRole user);
    }
}