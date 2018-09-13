/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events.Processing;
using Events.NationalSociety;

namespace Read.NationalSocietyFeatures
{
    public class NationalSocietyCreatedProcessor : ICanProcessEvents
    {
        readonly INationalSocieties _nationalSocieties;

        public NationalSocietyCreatedProcessor(INationalSocieties nationalSocieties)
        {
            _nationalSocieties = nationalSocieties;
        }

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