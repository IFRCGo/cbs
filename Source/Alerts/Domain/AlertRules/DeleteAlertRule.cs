using Concepts;
using Dolittle.Commands;

namespace Domain.AlertRules
{
    public class DeleteAlertRule : ICommand
    {
        public RuleId Id { get; set; }
    }
}