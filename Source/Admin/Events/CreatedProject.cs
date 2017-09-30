using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Events;

namespace Events
{
    public class CreatedProject:IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
