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
        public CaseReportIdentified(Guid caseReportId, Guid dataCollectorId) 
        {
            this.CaseReportId = caseReportId;
            this.DataCollectorId = dataCollectorId;
               
        }
        public Guid CaseReportId { get; }
        public Guid DataCollectorId { get; }
    }
}
