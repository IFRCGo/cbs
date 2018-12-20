using System;
using Dolittle.Commands;

namespace Domain.Tests
{
    //[Artifact("43c5c245-40ff-426d-a6f7-226427c142bb")]
    public class CreateHealthRiskTestData : ICommand
    {
        public Guid Id { get; set; }
    }
}