/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.AlertRules
{
    public class AlertRuleDeleted : IEvent
    {
        public Guid AlertRuleId { get; }

        public AlertRuleDeleted(Guid alertRuleId)
        {
            AlertRuleId = alertRuleId;
        }


    }
}
