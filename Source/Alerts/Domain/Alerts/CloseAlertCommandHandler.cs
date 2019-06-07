using Dolittle.Commands.Handling;
using Dolittle.Domain;
using System;

namespace Domain.Alerts
{
    public class CloseAlertCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<Alerts> _alertsAggregate;

        public CloseAlertCommandHandler(IAggregateRootRepositoryFor<Alerts> alertsAggregate)
        {
            _alertsAggregate = alertsAggregate;
        }

        public void Handle(CloseAlert closeAlert)
        {
            var id = Guid.NewGuid();
            var root = _alertsAggregate.Get(id);
            root.CloseAlert(closeAlert.AlertNumber);
        }
    }
}
