using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public abstract class NewRegistrationBusinessRulesValidator<T> : CommandBusinessValidator<T> where T: NewRegistration
    {
        readonly StaffUserIsRegistered _isRegistered;

        public NewRegistrationBusinessRulesValidator(StaffUserIsRegistered isRegistered)
        {
            _isRegistered = isRegistered;

            //Use ModelRule when the rule applies to the command as a whole or to multiple properties, not a specific property
            RuleFor(_ => _.UserDetails.StaffUserId).Must(NotBeAlreadyRegistered).WithMessage(_ => $"User '{_.UserDetails.StaffUserId}' is already registered.");
        }

        bool NotBeAlreadyRegistered(Guid staffUserId)
        {
            return !_isRegistered(staffUserId);
        }
    }
}