using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Alerts;
using Read.AlertRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.Alerts.Open
{
    public class EventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<OpenAlert> _items;
        private readonly IReadModelRepositoryFor<AlertRule> _rules;

        public EventProcessor(IReadModelRepositoryFor<OpenAlert> items, IReadModelRepositoryFor<AlertRule> rules)
        {
            _items = items;
            _rules = rules;
        }

        [EventProcessor("811df61b-d2c2-4cef-add1-ea3fa1ee3c86")]
        public void Process(AlertOpened @event)
        {
            var rule = _rules.GetById(@event.AlertRuleId);
            var item = new OpenAlert
            {
                Id = rule.HealthRiskId,
                AlertNumber = @event.AlertNumber,
                AlertId = @event.AlertId
            };
            _items.Insert(item);
        }
    }
}
