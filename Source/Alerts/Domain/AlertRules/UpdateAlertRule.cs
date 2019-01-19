using Concepts;
using Dolittle.Commands;

namespace Domain.AlertRules
{
    public class UpdateAlertRule : ICommand
    {
        public RuleId Id { get; set; }
    }
}