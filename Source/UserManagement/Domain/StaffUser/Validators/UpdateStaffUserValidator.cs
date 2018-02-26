using System;
using Domain.StaffUser.Commands;
using FluentValidation;

namespace Domain.StaffUser.Validators
{
    public class UpdateStaffUserValidator : AbstractValidator<UpdateStaffUser>
    {
        public UpdateStaffUserValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.StaffUserId)
                .NotEmpty().NotEqual(Guid.Empty).WithMessage("StaffUserId cannot be empty or equal to Guid.Empty");

            //TODO: Add validation rules
            RuleFor(_ => _.Role)
                .Empty().WithMessage("JKDJFSD");
        }
    }
}