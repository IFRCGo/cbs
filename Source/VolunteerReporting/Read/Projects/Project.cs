using System;
using Dolittle.ReadModels;

namespace Read.Projects
{
    public class Project : IReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
