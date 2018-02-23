using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Domain;
using doLittle.Runtime.Commands;

namespace Domain.StaffUser
{
    public class CommandHandlers : HandleCommand
    {
        private readonly IAggregateRootRepositoryFor<StaffUser> repository;
        public CommandHandlers(
            IAggregateRootRepositoryFor<StaffUser> repository)
        {
            this.repository = repository;
        }

        public void Handle(AddStaffUser command)
        {
            //TODO: ??
        }

    }
}
