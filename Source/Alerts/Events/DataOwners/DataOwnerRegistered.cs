using System;
using Dolittle.Events;
using Dolittle.Runtime.Events;

namespace Events.DataOwners
{
    public class DataOwnerRegistered : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }

        public DataOwnerRegistered(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
