/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
// CANNOT FIND THIS EVENT IN ANY BOUNDED CONTEXT
using System;
using Dolittle.Events;

namespace Events.External 
{
    public class UserCreated : IEvent 
    {
        
        public UserCreated (Guid id, string firstname, string lastname, string country, Guid nationalSocietyId) 
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Country = country;
            this.NationalSocietyId = nationalSocietyId;

        }
        public Guid Id { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Country { get; }

        public Guid NationalSocietyId { get; }
    }
}