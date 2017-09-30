using System;
using Infrastructure.Events;

namespace Events.External
{
    public class SingleCaseReported : IEvent
    {
        public Guid Id { get; set; }
    }
}
