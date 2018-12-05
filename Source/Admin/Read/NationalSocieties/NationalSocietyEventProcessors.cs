/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.NationalSocieties;

namespace Read.NationalSocieties
{
    public class NationalSocietyEventProcessors : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<NationalSociety> _nationalSocieties;


        public NationalSocietyEventProcessors(IReadModelRepositoryFor<NationalSociety> nationalSocieties)
        {
            _nationalSocieties = nationalSocieties;
        }
        
        [EventProcessor("6cd67e88-9246-4318-8155-a7433e3eebca")]
        public void Process(NationalSocietyCreated @event)
        {
            var nationalSociety = new NationalSociety()
            {
                Id = @event.Id,
                Name = @event.Name,
                Country = @event.Country,
                TimezoneOffsetFromUtcInMinutes = @event.TimezoneOffsetFromUtcInMinutes
            };
            _nationalSocieties.Insert(nationalSociety);
        }
    }
}