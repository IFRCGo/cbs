/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Management.DataCollectors.EditInformation
{
    public class DataCollectorPreferredLanguageChanged : IEvent
    {
        public int Language { get; }

        public DataCollectorPreferredLanguageChanged(int language)
        {
            Language = language;
        }
    }
}