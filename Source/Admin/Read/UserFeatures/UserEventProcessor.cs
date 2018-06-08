/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Events.External;

namespace Read.UserFeatures
{
    public class UserEventProcessor : ICanProcessEvents
    {
        readonly IUsers _users;

        public UserEventProcessor(IUsers users)
        {
            _users = users;
        }

        public void Process(UserCreated @event)
        {
            _users.Insert(new User
            {
                Country = @event.Country,
                Firstname = @event.Firstname,
                Id = @event.Id,
                NationalSocietyId = @event.NationalSocietyId,
                Lastname = @event.Lastname
            });
        }
    }
}