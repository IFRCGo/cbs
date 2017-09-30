using System;
using System.Collections.Generic;
using System.Text;

namespace Read
{
    public class ProjectEventProcessor : Infrastructure.Events.IEventProcessor
    {
        readonly IProjects _projects;
        public ProjectEventProcessor(IProjects projects)
        {
            _projects = projects;
        }

        public void Process()
        {

        }
    }
}
