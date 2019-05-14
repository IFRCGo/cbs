using System;
using System.Linq;
using Concepts.Alerts;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Alerts;
using Read.AlertRules;

namespace Read.Alerts
{
    public class AlertOverviewEventProcesor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<AlertOverview> _items;
        private readonly IReadModelRepositoryFor<AlertRule> _rules;

        public AlertOverviewEventProcesor(IReadModelRepositoryFor<AlertOverview> items, IReadModelRepositoryFor<AlertRule> rules)
        {
            _items = items;
            _rules = rules;
        }

        [EventProcessor("38d0113c-efd3-4c09-80d5-d14278ae5de7")]
        public void Process(AlertOpened @event)
        {
            var rule = _rules.GetById(@event.AlertRuleId);

            var item = new AlertOverview
            {
                AlertNumber = @event.AlertNumber,
                HealthRiskNumber = rule.HealthRiskId,
                HealthRiskName = rule.AlertRuleName,
                OpenedAt = DateTimeOffset.UtcNow,
                NumberOfReports = @event.Reports.Count(),
                Status = AlertStatus.Open
            };
            _items.Insert(item);
        }
    }
}
