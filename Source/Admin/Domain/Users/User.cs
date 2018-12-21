/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.NationalSocieties;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Users;

namespace Domain.Users
{
    public class User : AggregateRoot
    {
        public User(EventSourceId id) : base(id)
        { 
            
        }

        public void CreateUser(string fullName, string displayName, string country, NationalSocietyId nationalSocietyId)
        {
            Apply(new UserCreated(EventSourceId, fullName, displayName, country, nationalSocietyId));
        }
    }
}