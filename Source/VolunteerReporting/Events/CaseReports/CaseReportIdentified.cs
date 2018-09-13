/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.CaseReports
{
    public class CaseReportIdentified : IEvent
    {
        public Guid CaseReportId { get; set; }
        public Guid DataCollectorId { get; set; }
    }
}
