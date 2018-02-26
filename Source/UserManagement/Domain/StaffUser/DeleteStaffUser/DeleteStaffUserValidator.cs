using System;
using Domain.StaffUser.Commands;
using FluentValidation;

namespace Domain.StaffUser.Validators
{
    public class DeleteStaffUserValidator : AbstractValidator<DeleteStaffUser>
    {
        public DeleteStaffUserValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.StaffUserId)
                .NotEmpty().WithMessage("StaffUserId cannot be Empty")
                .NotEqual(Guid.Empty).WithMessage("StaffUserId cannot be Guid.Empty");

            RuleFor(_ => _.Role)
                .IsInEnum().WithMessage("Role is not correct");
        }
        
    }
}