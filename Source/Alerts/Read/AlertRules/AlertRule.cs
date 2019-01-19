using Concepts;
using Dolittle.ReadModels;

namespace Read.AlertRules
{
    public class AlertRule: IReadModel
    {
        public RuleId Id { get; set; }
    }
}