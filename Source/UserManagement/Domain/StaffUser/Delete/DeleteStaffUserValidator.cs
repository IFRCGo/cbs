using System;
using FluentValidation;

namespace Domain.StaffUser.Delete
{
    public class DeleteStaffUserValidator : AbstractValidator<DeleteStaffUser>
    {
        public DeleteStaffUserValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.StaffUserId)
                .NotEmpty().WithMessage("StaffUserId cannot be Empty")
                .NotEqual(Guid.Empty).WithMessage("StaffUserId cannot be Guid.Empty");
        }
        
    }
}