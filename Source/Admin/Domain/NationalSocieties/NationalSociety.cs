/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.NationalSocieties;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.NationalSocieties;

namespace Domain.NationalSocieties
{
    public class NationalSociety : AggregateRoot
    {
        public NationalSociety(EventSourceId id) : base(id)
        { 
            
        }

        public void CreateNationalSociety(
            NationalSocietyName name,
            string country,
            int timezoneOffsetFromUtcInMinutes
        )
        {
            Apply(new NationalSocietyCreated(EventSourceId, name, country, timezoneOffsetFromUtcInMinutes));
        }

    }
}
