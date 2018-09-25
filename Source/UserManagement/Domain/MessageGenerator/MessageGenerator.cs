using Dolittle.Domain;
using Events.MessageGenerator;
using System;

namespace Domain.MessageGenerator
{
    public class MessageGenerator : AggregateRoot
    {
        public MessageGenerator(Guid id) : base(id) { }

        public void GenerateMessage(GenerateMessage command) 
        {
            Apply(new MessageGenerated(command.Id, command.PhoneNumber, command.Message));
        }
    }
}
