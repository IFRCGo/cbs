/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.HealthRisks
{
    public class HealthRiskCommandHandler : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<HealthRisk> _aggregate;

        public HealthRiskCommandHandler(IAggregateRootRepositoryFor<HealthRisk> aggregate)
        {
            _aggregate = aggregate;
        }

        public void Handle(CreateHealthRisk cmd)
        {
            var root = _aggregate.Get(cmd.Id);
            root.CreateHealthRisk(cmd.Name, cmd.CaseDefinition, cmd.Number);
        }

        public void Handle(ModifyHealthRisk cmd)
        {
            var root = _aggregate.Get(cmd.Id);
            root.ModifyHealthRisk(cmd.Name, cmd.CaseDefinition, cmd.ReadableId);
        }

        public void Handle(AddThresholdToHealthRisk cmd)
        {
            var root = _aggregate.Get(cmd.HealthRiskId);
            root.AddThresholdToHealthRisk(cmd.Threshold);
        }

        public void Handle(DeleteHealthRisk cmd)
        {
            var root = _aggregate.Get(cmd.HealthRiskId);
            root.DeleteHealthRisk();
        }
    }
}