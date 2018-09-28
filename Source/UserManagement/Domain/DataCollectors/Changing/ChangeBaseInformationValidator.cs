using System;
using Concepts.DataCollector;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors.Changing
{
   
    public class ChangeBaseInformationValidator : CommandInputValidatorFor<ChangeBaseInformation>
    {
        public ChangeBaseInformationValidator()
        {

            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());
                
            RuleFor(_ => _.FullName)
                .NotEmpty().WithMessage("Full Name is not correct - Has to be defined");

            RuleFor(_ => _.DisplayName)
                .NotEmpty().WithMessage("Display Name is not correct - Has to be defined");

            //TODO: Add later
            //RuleFor(_ => _.Email)
            //    .Cascade(CascadeMode.StopOnFirstFailure)
            //    .EmailAddress().WithMessage("Email address must be valid");

            RuleFor(_ => _.Sex)
                .IsInEnum().WithMessage("Sex is invalid").When(s => s != null);


            RuleFor(_ => _.YearOfBirth) // For now, Year of birth is mandatory
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Year of birth is required")
                .InclusiveBetween(1900, DateTime.UtcNow.Year).WithMessage("Year of birth must be greater than 1900 and less than " + DateTimeOffset.UtcNow.Year);
            
            RuleFor(_ => _.District)
                .NotEmpty().WithMessage("District is not correct - Has to be defined");

            RuleFor(_ => _.Region)
                .NotEmpty().WithMessage("Region is not correct - Has to be defined");

        }
    }
    
}