using System;
using Dolittle.Concepts;

namespace Concepts.Project
{
    public class ProjectId : ConceptAs<Guid>
    {
        public static implicit operator ProjectId (Guid value) 
        {
            return new ProjectId{ Value = value };
        }
    }
}