using System;
using Domain.StaffUser.Roles;
using FluentValidation;

namespace Domain.StaffUser.PhoneNumber
{
    public class RemovePhoneNumberFromStaffUserValidator : AbstractValidator<RemovePhoneNumberFromStaffUser>
    {
        public RemovePhoneNumberFromStaffUserValidator()
        {
            RuleFor(_ => _.StaffUserId)
                .NotEmpty().WithMessage("StaffUserId cannot be empty")
                .NotEqual(Guid.Empty).WithMessage("StaffUserId cannot be Guid.Empty");

            RuleFor(_ => _.Role)
                .IsInEnum().WithMessage("The Staffuser role must be specified")
                .Must(role => role.HasPhoneNumbers()).WithMessage("This kind of Staffuser does not have phone numbers");

            RuleFor(_ => _.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber cannot be empty");

            // TODO: Add aditional rules here
        }
    }
}