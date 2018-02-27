using System;
<<<<<<< HEAD
=======
using Domain.DataCollector.Update;
>>>>>>> 0e304c99aa928cef3f5308a15ea685a35cce0d0e
using FluentValidation;

namespace Domain.DataCollector.PhoneNumber
{
    public class RemovePhoneNumberFromDataCollectorValidator : AbstractValidator<RemovePhoneNumberFromDataCollector>
    {
        public RemovePhoneNumberFromDataCollectorValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("DataCollectorId cannot be empty")
                .NotEqual(Guid.Empty).WithMessage("DataCollectorId cannot be Guid.Empty");


            RuleFor(_ => _.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber cannot be empty");
            // TODO: Add aditional rules here
        }
    }
}