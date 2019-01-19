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
            var root = _aggregate.Get(cmd.Id.Value);
            root.CreateAlertRule();
        }

        public void Handle(UpdateAlertRule cmd)
        {
            var root = _aggregate.Get(cmd.Id.Value);
            root.CreateAlertRule();
        }

        public void Handle(DeleteAlertRule cmd)
        {
            var root = _aggregate.Get(cmd.Id.Value);
            root.DeleteAlertRule();
        }
    }
}
