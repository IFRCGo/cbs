using System;
using Domain.StaffUser.PhoneNumber;
using FluentValidation;

namespace Domain.StaffUser.Update
{
    public class UpdateStaffUserValidator : AbstractValidator<BaseStaffUser>
    {
        public UpdateStaffUserValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.StaffUserId)
                .NotEmpty().NotEqual(Guid.Empty).WithMessage("StaffUserId cannot be empty or equal to Guid.Empty");

            //TODO: Add validation rules
        }
    }
}