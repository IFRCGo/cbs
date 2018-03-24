using System;
using FluentValidation;

namespace Domain.StaffUser.PhoneNumber
{
    public class RemovePhoneNumberFromStaffUserValidator : AbstractValidator<RemovePhoneNumberFromStaffUser>
    {
        public RemovePhoneNumberFromStaffUserValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.StaffUserId)
                .NotEmpty().WithMessage("StaffUserId cannot be empty")
                .NotEqual(Guid.Empty).WithMessage("StaffUserId cannot be Guid.Empty");

            RuleFor(_ => _.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber cannot be empty");
            // TODO: Add aditional rules here
        }
    }
}