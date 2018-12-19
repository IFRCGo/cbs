/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.DataCollectors.Changing
{
    public class DataCollectorPreferredLanguageChanged : IEvent
    {
        public Guid DataCollectorId { get; }
        public int Language { get; }

        public DataCollectorPreferredLanguageChanged(Guid dataCollectorId, int language)
        {
            DataCollectorId = dataCollectorId;
            Language = language;
        }
    }
}