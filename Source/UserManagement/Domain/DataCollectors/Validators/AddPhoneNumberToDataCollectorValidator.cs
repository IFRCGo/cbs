using System;
using Domain.DataCollectors.Commands;
using FluentValidation;

namespace Domain.DataCollectors.Validators
{
    public class AddPhoneNumberToDataCollectorValidator : AbstractValidator<AddPhoneNumberToDataCollector>
    {
        public AddPhoneNumberToDataCollectorValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("DataColelctorId cannot be empty")
                .NotEqual(Guid.Empty).WithMessage("StaffUserId cannot be Guid.Empty");


            RuleFor(_ => _.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber cannot be empty");
            // TODO: Add aditional rules here
        }
    }
}