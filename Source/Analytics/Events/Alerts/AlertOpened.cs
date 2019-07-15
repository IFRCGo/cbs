/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Alerts
{
    [Artifact("0c6aadaa-e2a3-474d-a630-8a2b2bca2f19", 1)]
    public class AlertOpened : IEvent
    {
        public AlertOpened(Guid alertId, Guid alertRuleId, uint alertNumber, Guid[] reports)
        {
            AlertId = alertId;
            AlertRuleId = alertRuleId;
            AlertNumber = alertNumber;
            Reports = reports;
        }

        public Guid AlertId { get; }
        public Guid AlertRuleId { get; }
        public uint AlertNumber { get; }
        public Guid[] Reports { get; }
    }
}
