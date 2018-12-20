using System;
using Dolittle.Commands;

namespace Domain.Tests
{
    //[Artifact("fa742b5c-15aa-441a-991c-61d154898a30")]
    public class CreateUserTestData : ICommand
    {
        public Guid Id { get; set; }
    }
}
