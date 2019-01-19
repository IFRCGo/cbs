using Concepts.DataOwners;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.DataOwners;

namespace Domain.DataOwners
{
    public class DataOwner : AggregateRoot
    {
        public DataOwner(EventSourceId id) : base(id)
        {

        }

        public void RegisterDataOwner(NameOfDataOwner name, Email email)
        {
            Apply(new DataOwnerRegistered(EventSourceId, name, email));
        }
    }
}
