using System;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollector.Changing
{
   
    public class ChangeBaseInformationValidator : CommandInputValidatorFor<ChangeBaseInformation>
    {
        public ChangeBaseInformationValidator()
        {

            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set");

            RuleFor(_ => _.FullName)
                .NotEmpty()
                .WithMessage("Full Name is not correct - Has to be defined");

            RuleFor(_ => _.DisplayName)
                .NotEmpty()
                .WithMessage("Display Name is not correct - Has to be defined");

            //TODO: Add later
            //RuleFor(_ => _.Email)
            //    .Cascade(CascadeMode.StopOnFirstFailure)
            //    .EmailAddress().WithMessage("Email address must be valid");

            RuleFor(_ => _.Sex)
                .IsInEnum().WithMessage("Sex is invalid").When(s => s != null);


            RuleFor(_ => _.YearOfBirth)
                .InclusiveBetween(1900, DateTime.UtcNow.Year).WithMessage("Year of birth is required").When(y => y != null);
            

        }
    }
    
}