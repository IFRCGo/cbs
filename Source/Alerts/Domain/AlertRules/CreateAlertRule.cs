using Concepts;
using Dolittle.Commands;

namespace Domain.AlertRules
{
    public class CreateAlertRule : ICommand
    {
        public RuleId Id { get; set; }
    }
}
