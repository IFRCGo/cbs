/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/


using System;
using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.AlertRules
{
    public class AlertRuleCommandHandler : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<AlertRule> _aggregate;

        public AlertRuleCommandHandler(IAggregateRootRepositoryFor<AlertRule> aggregate)
        {
            _aggregate = aggregate;
        }

        public void Handle(CreateAlertRule cmd)
        {
            var id = Guid.NewGuid();
            var root = _aggregate.Get(id);
            root.CreateAlertRule(cmd.AlertRuleName, cmd.HealthRiskNumber, cmd.NumberOfCasesThreshold, cmd.DistanceBetweenCasesInMeters, cmd.ThresholdTimeframeInHours);
        }

        public void Handle(UpdateAlertRule cmd)
        {
            var root = _aggregate.Get(cmd.Id.Value);
            root.UpdateAlertRule(cmd.AlertRuleName, cmd.HealthRiskNumber, cmd.NumberOfCasesThreshold, cmd.DistanceBetweenCasesInMeters, cmd.ThresholdTimeframeInHours);
        }

        public void Handle(DeleteAlertRule cmd)
        {
            var root = _aggregate.Get(cmd.Id.Value);
            root.DeleteAlertRule(cmd.Id.Value);
        }
    }
}
