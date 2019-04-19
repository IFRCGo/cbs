using System;
using Dolittle.Runtime.Events;
using Domain.DataOwners;
using Machine.Specifications;

namespace Policies.Specs.for_AlertRules.given
{
    public class an_aggregate
    {
        protected static DataOwner event_source;
        protected static EventSourceId event_source_id;

        Establish context = () => 
        {
            event_source_id = Guid.NewGuid();
            event_source = new DataOwner(event_source_id);
        };
    }
}