using System;
using System.Collections.Generic;
using System.Text;
using Concepts;
using doLittle.Domain;
using doLittle.Runtime.Events;
using Events.StaffUser;
namespace Domain.StaffUser
{
    public class StaffUser : AggregateRoot
    {
        protected StaffUser(EventSourceId id) : base(id) {}

        //TODO: I have no idea, not even sure what AggregateRoot means. Someone should look over this.
        public void AddStaffUser(AddStaffUser command)
        {
            switch (command.Role)
            {
                case Role.Admin:
                    HandleAdmin(command);
                    break;
                case Role.DataConsumer:
                    HandleDataConsumer(command);
                    break;
                case Role.DataCoordinator:
                    HandleDataCoordinator(command);
                    break;
                case Role.DataOwner:
                    HandleDataOwner(command);
                    break;
                case Role.DataVerifier:
                    HandleDataVerifier(command);
                    break;
                case Role.SystemCoordinator:
                    HandleSystemCoordinator(command);
                    break;
            }
        }

        private void HandleAdmin(AddStaffUser command)
        {
            Apply(new AdminAdded(
                Guid.NewGuid(), command.FullName,
                command.DisplayName, command.Email
                ));
        }
        private void HandleDataConsumer(AddStaffUser command)
        {
            Apply(new DataConsumerAdded(
                Guid.NewGuid(), command.FullName,
                command.DisplayName, command.Email,
                command.Location.Longitude, command.Area.Latitude
                ));
        }
        private void HandleDataCoordinator(AddStaffUser command)
        {
            Apply(new DataCoordinatorAdded(
                Guid.NewGuid(), command.FullName, command.DisplayName,
                command.Email,command.Age, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude, command.GeoLocation, command.MobilePhoneNumber,
                command.AssignedNationalSociety
                ));
        }
        private void HandleDataOwner(AddStaffUser command)
        {
            Apply(new DataOwnerAdded(
                Guid.NewGuid(), command.FullName, command.DisplayName,
                command.Email, command.Age, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude, command.GeoLocation, command.MobilePhoneNumber,
                command.AssignedNationalSociety, command.Position, command.DutyStation
                ));
        }
        private void HandleDataVerifier(AddStaffUser command)
        {
            Apply(new DataVerifierAdded(
                Guid.NewGuid(), command.FullName, command.DisplayName,
                command.Email, command.Age, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude, command.GeoLocation, command.MobilePhoneNumber,
                command.AssignedNationalSociety, DateTime.Now
                ));
        }
        private void HandleSystemCoordinator(AddStaffUser command)
        {
            Apply(new SystemCoordinatorAdded(
                Guid.NewGuid(), command.FullName, command.DisplayName,
                command.Email, command.Age, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude, command.GeoLocation, command.MobilePhoneNumber,
                command.AssignedNationalSociety
                ));
        }
    }
}
