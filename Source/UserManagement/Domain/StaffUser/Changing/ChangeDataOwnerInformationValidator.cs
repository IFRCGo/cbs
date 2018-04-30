using System;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.StaffUser.Changing
{
    public class ChangeDataOwnerInformationValidator : CommandInputValidatorFor<ChangeDataOwnerInformation>
    {
        public ChangeDataOwnerInformationValidator()
        {
            RuleFor(_ => _.StaffUserId)
                .NotEmpty().WithMessage("Staffuser Id cannot be empty")
                .NotEqual(Guid.Empty).WithMessage("Staffuser id cannot be empty");

            RuleFor(_ => _.DutyStation)
                .NotEmpty().WithMessage("Duty station cannot be empty");

            RuleFor(_ => _.Position)
                .NotEmpty().WithMessage("Position cannot be empty");
        }
    }
}