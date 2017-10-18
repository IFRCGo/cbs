/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Events;
using Events.External;
using Infrastructure.Events;

namespace Read.UserFeatures
{
    public class UserEventProcessor : IEventProcessor
    {
        readonly IUsers _users;

        public UserEventProcessor(IUsers users)
        {
            _users = users;
        }

        public void Process(UserCreated @event)
        {
            var user = _users.GetById(@event.Id);
            user.Firstname = @event.Firstname;
            user.Lastname = @event.Lastname;
            user.Country = @event.Country;
            user.NationalSocietyId = @event.NationalSocietyId;

            _users.Save(user);
        }
    }
}