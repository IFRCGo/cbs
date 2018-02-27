using System;
using Domain.DataCollector.UpdateDataCollector;
using FluentValidation;

namespace Domain.DataCollector.PhoneNumber
{
    public class RemovePhoneNumberFromDataCollectorValidator : AbstractValidator<RemovePhoneNumberFromDataCollector>
    {
        public RemovePhoneNumberFromDataCollectorValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("DataCollectorId cannot be empty")
                .NotEqual(Guid.Empty).WithMessage("DataCollectorId cannot be Guid.Empty");


            RuleFor(_ => _.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber cannot be empty");
            // TODO: Add aditional rules here
        }
    }
}