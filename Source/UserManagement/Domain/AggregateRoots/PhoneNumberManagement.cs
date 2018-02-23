using System;
using doLittle.Domain;
using doLittle.Runtime.Events;
using Domain.DataCollectors;
using Events.DataCollector;
using Events.StaffUser;

namespace Domain.AggregateRoots
{
    public class PhoneNumberManagement : AggregateRoot
    {
        protected PhoneNumberManagement(EventSourceId id) : base(id)
        {
        }

        public void AddPhoneNumber(AddPhoneNumber command)
        {
            if (command.StaffUserId.HasValue && command.StaffUserId.Value != Guid.Empty)
            { // Must have correct information for adding phonenumber to staffuser
                HandleStaffUserPhoneAdded(command);
            }
            else
            { // If something fails here it's the Validator's fault.
                HandleDataCollectorPhoneAdded(command);
            }
        }

        public void RemovePhoneNumber(RemovePhoneNumber command)
        {
            if (command.StaffUserId.HasValue && command.StaffUserId.Value != Guid.Empty)
            { // Must have correct information for adding phonenumber to staffuser
                HandleStaffUserPhoneRemoved(command);
            }
            else
            { // If something fails here it's the Validator's fault.
                HandleDataCollectorPhoneRemoved(command);
            }
        }

        private void HandleStaffUserPhoneAdded(AddPhoneNumber command)
        {
            Apply(new PhoneNumberAddedToStaffUser(
                command.StaffUserId.Value, command.PhoneNumber, (int)command.Role.Value
            ));
        }
        private void HandleDataCollectorPhoneAdded(AddPhoneNumber command)
        {
            Apply(new PhoneNumberAddedToDataCollector(
                command.DataCollectorId.Value, command.PhoneNumber
            ));
        }
        private void HandleStaffUserPhoneRemoved(RemovePhoneNumber command)
        {
            Apply(new PhoneNumberRemovedFromStaffUser(
                command.StaffUserId.Value, command.PhoneNumber, (int)command.Role.Value
                ));
        }
        private void HandleDataCollectorPhoneRemoved(RemovePhoneNumber command)
        {
            Apply(new PhoneNumberRemovedFromDataCollector(
                command.DataCollectorId.Value, command.PhoneNumber
                ));
        }
    }
}