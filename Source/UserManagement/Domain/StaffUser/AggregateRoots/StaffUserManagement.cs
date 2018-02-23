using System;
using Concepts;
using doLittle.Domain;
using Events.StaffUser;

namespace Domain.StaffUser.AggregateRoots
{
    public class StaffUserManagement : AggregateRoot
    {
        public StaffUserManagement(Guid id) : base(id)
        {
        }
        
        public void AddStaffUser(AddStaffUser command)
        {
            switch (command.Role)
            {
                case Role.Admin:
                    HandleAddAdmin(command);
                    break;
                case Role.DataConsumer:
                    HandleAddDataConsumer(command);
                    break;
                case Role.DataCoordinator:
                    HandleAddDataCoordinator(command);
                    break;
                case Role.DataOwner:
                    HandleAddDataOwner(command);
                    break;
                case Role.DataVerifier:
                    HandleAddDataVerifier(command);
                    break;
                case Role.SystemCoordinator:
                    HandleAddSystemCoordinator(command);
                    break;

                default:
                    //TODO: This should not happen due to InputValidation
                    break;
                
            }
        }

        // TODO: Should events get the ID from this AggregateRoot object, or a completly new Guid created here?

        // QUESTION: I don't really understand the EventSourceId thing and how it functions here in the AggregateRoot.
        // Should Events have a seperate EventSourceId field?

        private void HandleAddAdmin(AddStaffUser command)
        {
            Apply(new AdminAdded(
                EventSourceId, command.FullName,
                command.DisplayName, command.Email
                ));
        }

        private void HandleAddDataConsumer(AddStaffUser command)
        {
            Apply(new DataConsumerAdded(
                EventSourceId, command.FullName,
                command.DisplayName, command.Email,
                command.Location.Longitude, command.Area.Latitude
                ));
        }
        private void HandleAddDataCoordinator(AddStaffUser command)
        {
            Apply(new DataCoordinatorAdded(
                EventSourceId, command.FullName, command.DisplayName,
                command.Email, command.Age, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude, command.GeoLocation, command.MobilePhoneNumber,
                command.AssignedNationalSociety
                ));
        }
        private void HandleAddDataOwner(AddStaffUser command)
        {
            Apply(new DataOwnerAdded(
                EventSourceId, command.FullName, command.DisplayName,
                command.Email, command.Age, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude, command.GeoLocation, command.MobilePhoneNumber,
                command.AssignedNationalSociety, command.Position, command.DutyStation
                ));
        }
        private void HandleAddDataVerifier(AddStaffUser command)
        {
            Apply(new DataVerifierAdded(
                EventSourceId, command.FullName, command.DisplayName,
                command.Email, command.Age, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude, command.GeoLocation, command.MobilePhoneNumber,
                command.AssignedNationalSociety, DateTime.Now
                ));
        }
        private void HandleAddSystemCoordinator(AddStaffUser command)
        {
            Apply(new SystemCoordinatorAdded(
                EventSourceId, command.FullName, command.DisplayName,
                command.Email, command.Age, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude, command.GeoLocation, command.MobilePhoneNumber,
                command.AssignedNationalSociety
                ));
        }
    }
}
