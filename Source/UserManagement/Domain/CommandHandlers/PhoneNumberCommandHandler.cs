using System;
using doLittle.Domain;
using doLittle.Runtime.Commands;
using Domain.AggregateRoots;
using Domain.DataCollectors;

namespace Domain.CommandHandlers
{
    public class PhoneNumberCommandHandler : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<PhoneNumberManagement> _repository;

        public PhoneNumberCommandHandler(
            IAggregateRootRepositoryFor<PhoneNumberManagement> repository
        )
        {
            _repository = repository;
        }

        public void Handle(AddPhoneNumber command)
        {
            var root = _repository.Get(Guid.NewGuid());

            root.AddPhoneNumber(command);
        }

        public void Handle(RemovePhoneNumber command)
        {
            var root = _repository.Get(Guid.NewGuid());
            root.RemovePhoneNumber(command);
        }
    }
}