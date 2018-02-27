using System;
using doLittle.Domain;
using Domain.StaffUser;
using Domain.StaffUser.Delete;
using Domain.StaffUser.PhoneNumber;
using Domain.StaffUser.Update;

namespace Domain.StaffUser
{
    public class StaffUserCommandHandler : IStaffUserCommandHandler
    {
        private readonly IAggregateRootRepositoryFor<StaffUserManagement> _repository;

        public StaffUserCommandHandler(
            IAggregateRootRepositoryFor<StaffUserManagement> repository)
        {
            _repository = repository;
        }

        public void Handle(AddAdmin command)
        {
            var root = _repository.Get(command.StaffUserId);

            root.AddStaffUser(command);
        }

        //TODO: Probably need to create an UpdateStaffUser command and corresponding events?

        public void Handle(DeleteStaffUser command)
        {
            var root = _repository.Get(command.StaffUserId);
            // TODO: Call StaffUserManagement DeleteStaffUser
            //root.DeleteStaffUser(command);
        }

        public void Handle(UpdateStaffUser command)
        {
            var root = _repository.Get(command.StaffUserId);
            root.UpdateStaffUser(command);

        }

        public void Handle(AddPhoneNumberToStaffUser command)
        {
            var root = _repository.Get(command.StaffUserId);
            root.AddPhoneNumber(command);
        }

        public void Handle(RemovePhoneNumberFromStaffUser command)
        {
            var root = _repository.Get(command.StaffUserId);
            root.RemovePhoneNumber(command);
        }
    }
}
