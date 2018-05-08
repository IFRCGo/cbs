using System;

namespace Read.Projects
{
    public class Project : IReadModel<Guid>
    {
    public Guid Id { get; set; }
    public string Name { get; set; }
    }
}
