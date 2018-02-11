using doLittle.Domain;
using Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MessageGenerators
{
    public class MessageGenerator : AggregateRoot
    {
        public MessageGenerator(Guid id) : base(id) { }

        public void GenerateMessage(GenerateMessage command) 
        {
            Apply(new MessageGenerated
            {
                Id = command.Id,
                PhoneNumber = command.PhoneNumber,
                Message = command.Message
            });
        }
    }
}
