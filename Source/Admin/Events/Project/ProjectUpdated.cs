/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Project
{
    public class ProjectUpdated : IEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public Guid NationalSocietyId { get; set; }
        public Guid DataOwnerId { get; set; }

        public int SurveillanceContext { get; set; }

        public string SmsProxy { get; set; }
    }
}