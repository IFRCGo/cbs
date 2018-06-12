using System;
using Concepts;
using Dolittle.ReadModels;

namespace Read.Projects
{
    public class Project : IReadModel
    {
        public ProjectId Id { get; set; }

        public string Name { get; set; }
    }
}
