using doLittle.Domain;
using Events.StaffUser;
using doLittle.Events;
using System;

namespace Domain.StaffUser
{
    public class StaffUser : AggregateRoot
    {
        bool _isRegistered;

        public StaffUser(Guid staffUserId) : base(staffUserId)
        {}

        public void RegisterNewAdminUser(string fullname, string displayname, string email, DateTimeOffset registeredAt)
        {
            if(_isRegistered)
                throw new UserAlreadyRegistered($"User '{EventSourceId}' {email} {displayname} is already registered.");
            
            Apply(new NewAdminUserRegistered(EventSourceId, fullname, displayname, email, registeredAt));
        }

        void On(NewAdminUserRegistered @event)
        {
            _isRegistered = true;
        }
    }
}