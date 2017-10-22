using System;
using System.Collections.Generic;
using System.Text;
using Events;
using Events.External;

namespace Read
{
    public class UserEventProcessor : Infrastructure.Events.IEventProcessor
    {
        private readonly IUsers _users;

        public UserEventProcessor(IUsers users)
        {
            _users = users;
        }

        public void Process(UserCreated @event)
        {
            var user = _users.GetById(@event.Id);
            if (user == null)
            {
                user = new User()
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    PhoneNumber = @event.PhoneNumber,
                    Email = @event.Email,
                    Geo = @event.Geo,
                    RecipientType = @event.UserType
                };
            }
            else
            {
                user.Id = @event.Id;
                user.Name = @event.Name;
                user.PhoneNumber = @event.PhoneNumber;
                user.Email = @event.Email;
                user.Geo = @event.Geo;
                user.RecipientType = @event.UserType;
            }
           _users.Save(user);
        }

        public void Process(UserUpdatedEvent @event)
        {
            var user = _users.GetById(@event.Id);
            if (user == null)
            {
                user = new User()
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    PhoneNumber = @event.PhoneNumber,
                    Email = @event.Email,
                    Geo = @event.Geo,
                    RecipientType = @event.UserType
                };
            }
            else
            {
                user.Id = @event.Id;
                user.Name = @event.Name;
                user.PhoneNumber = @event.PhoneNumber;
                user.Email = @event.Email;
                user.Geo = @event.Geo;
                user.RecipientType = @event.UserType;
            }
            _users.Save(user);
        }
    }
}
