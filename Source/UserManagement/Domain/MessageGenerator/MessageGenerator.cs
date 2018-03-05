using doLittle.Domain;
using Events;
using System;

namespace Domain.MessageGenerator
{
    public class MessageGenerator : AggregateRoot
    {
        public MessageGenerator(Guid id) : base(id) { }

        public void GenerateMessage(GenerateMessage command) 
        {
            Apply(new MessageGenerated
            {
                DataCollectorId = command.Id,
                PhoneNumber = command.PhoneNumber,
                Message = command.Message
            });
        }
    }
}
