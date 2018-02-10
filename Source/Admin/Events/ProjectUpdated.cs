/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using doLittle.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Events
{
    public class ProjectUpdated : IEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public Guid NationalSocietyId { get; set; }
        public Guid DataOwnerId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ProjectSurveillanceContext SurveillanceContext { get; set; }
        public string SMSGateWay { get; set; }

    }
}