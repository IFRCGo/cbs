using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Domain;
using doLittle.Runtime.Commands;
using Domain.StaffUser.AggregateRoots;
using Domain.StaffUser.Commands;

namespace Domain.StaffUser.CommandHandlers
{
    public class StaffUserCommandHandler : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<StaffUserManagement> _repository;
        public StaffUserCommandHandler(
            IAggregateRootRepositoryFor<StaffUserManagement> repository)
        {
            _repository = repository;
        }

        public void Handle(AddStaffUser command)
        {
            var root = _repository.Get(Guid.NewGuid());

            root.AddStaffUser(command);
        }

        //TODO: Probably need to create an UpdateStaffUser command and corresponding events?

        public void Handle(DeleteStaffUser command)
        {
            var staffUserMng = _repository.Get(command.StaffUserId);
            // TODO: Call StaffUserManagement DeleteStaffUser
        }
    }
}
