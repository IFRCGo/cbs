using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Read
{
    public class ProjectRoles : Repository<ProjectRole>, IProjectRoles
    {
        public ProjectRoles(IMongoDatabase database) : base(database, "ProjectRole")
        {
        }
    }
}
