/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.NationalSocietyFeatures
{
	public class NationalSocietyCreatedProcessor : Infrastructure.Events.IEventProcessor
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
                Country = @event.Country
				
			};
			_nationalSocieties.Save(nationalSociety);
		}
	}
}
