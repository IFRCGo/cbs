/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Events;

namespace Events
{
    public class HealthRisksSetForProject : IEvent
    {
        public Guid ProjectId { get; set; }
        public Guid[] HealthRiskIds { get; set; }
    }
}
