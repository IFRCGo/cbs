using System;
using Concepts;
using Concepts.Project;
using Dolittle.ReadModels;

namespace Read.Projects
{
    public class Project : IReadModel
    {
        public ProjectId Id { get; set; }

        public string Name { get; set; }
    }
}
