using System;
using Concepts;
using doLittle.Domain;
using Domain.StaffUser.Commands;
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

        public void AddPhoneNumber(AddPhoneNumberToStaffUser command)
        {
            Apply(new PhoneNumberAddedToStaffUser(
                command.StaffUserId, command.PhoneNumber, (int)command.Role
                ));
        }

        public void RemovePhoneNumber(RemovePhoneNumberFromStaffUser command)
        {
            Apply(new PhoneNumberRemovedFromStaffUser(
                command.StaffUserId, command.PhoneNumber, (int)command.Role
                ));
        }

        private void HandleAddAdmin(AddStaffUser command)
        {
            Apply(new AdminAdded(
                command.StaffUserId, command.FullName,
                command.DisplayName, command.Email
                ));

        }

        private void HandleAddDataConsumer(AddStaffUser command)
        {
            Apply(new DataConsumerAdded(
                command.StaffUserId, command.FullName,
                command.DisplayName, command.Email,
                command.Location.Longitude, command.Location.Latitude
                ));
        }
        private void HandleAddDataCoordinator(AddStaffUser command)
        {
            Apply(new DataCoordinatorAdded(
                command.StaffUserId, command.FullName, command.DisplayName,
                command.Email, command.YearOfBirth, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude
                ));

            if (command.MobilePhoneNumber != null && command.MobilePhoneNumber.Count > 0)
            {
                foreach (var number in command.MobilePhoneNumber)
                {
                    Apply(new PhoneNumberAddedToStaffUser(
                        command.StaffUserId, number,
                        (int)command.Role
                    ));
                }
            }
            //TODO: DO the same for NationalSocieties
        }
        private void HandleAddDataOwner(AddStaffUser command)
        {
            Apply(new DataOwnerAdded(
                command.StaffUserId, command.FullName, command.DisplayName,
                command.Email, command.YearOfBirth, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude, command.Position, command.DutyStation
                ));

            if (command.MobilePhoneNumber != null && command.MobilePhoneNumber.Count > 0)
            {
                foreach (var number in command.MobilePhoneNumber)
                {
                    Apply(new PhoneNumberAddedToStaffUser(
                        command.StaffUserId, number,
                        (int)command.Role
                    ));
                }
            }
            //TODO: DO the same for NationalSocieties
        }
        private void HandleAddDataVerifier(AddStaffUser command)
        {
            Apply(new DataVerifierAdded(
                command.StaffUserId, command.FullName, command.DisplayName,
                command.Email, command.YearOfBirth, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude, DateTimeOffset.UtcNow
                ));

            if (command.MobilePhoneNumber != null && command.MobilePhoneNumber.Count > 0)
            {
                foreach (var number in command.MobilePhoneNumber)
                {
                    Apply(new PhoneNumberAddedToStaffUser(
                        command.StaffUserId, number,
                        (int)command.Role
                    ));
                }
            }
            //TODO: DO the same for NationalSocieties
        }
        private void HandleAddSystemCoordinator(AddStaffUser command)
        {
            Apply(new SystemCoordinatorAdded(
                command.StaffUserId, command.FullName, command.DisplayName,
                command.Email, command.YearOfBirth, (int)command.Sex, command.NationalSociety,
                (int)command.PreferredLanguage, command.Location.Longitude,
                command.Location.Latitude
                ));

            if (command.MobilePhoneNumber != null && command.MobilePhoneNumber.Count > 0)
            {
                foreach (var number in command.MobilePhoneNumber)
                {
                    Apply(new PhoneNumberAddedToStaffUser(
                        command.StaffUserId, number,
                        (int)command.Role
                    ));
                }
            }
            //TODO: DO the same for NationalSocieties
        }
    }
}
