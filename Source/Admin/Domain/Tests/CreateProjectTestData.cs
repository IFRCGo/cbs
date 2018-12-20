using System;
using Dolittle.Commands;

namespace Domain.Tests
{
    //[Artifact("984a0822-9baf-4daf-a43a-cc41645fb885")]
    public class CreateProjectTestData : ICommand
    {
        public Guid Id { get; set; }
    }
}
