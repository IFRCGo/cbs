using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.DataOwners
{
    public class RegisterOwnerCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<DataOwner> _aggregateRoot;

        public RegisterOwnerCommandHandler(IAggregateRootRepositoryFor<DataOwner> aggregateRoot)
        {
            _aggregateRoot = aggregateRoot;
        }

        public void Handle(RegisterDataOwner cmd)
        {
            var root = _aggregateRoot.Get(cmd.Id.Value);
            root.RegisterDataOwner(cmd.Name,cmd.Email);
        }

    }
}
