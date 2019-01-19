/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.EditInformation
{
   
    public class ChangeBaseInformationInputValidator : CommandInputValidatorFor<ChangeBaseInformation>
    {
        public ChangeBaseInformationInputValidator()
        {

            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());
                
            RuleFor(_ => _.FullName)
                .NotEmpty().WithMessage("Full Name is not correct - Has to be defined");

            RuleFor(_ => _.DisplayName)
                .NotEmpty().WithMessage("Display Name is not correct - Has to be defined");

            RuleFor(_ => _.Sex)
                .IsInEnum().WithMessage("Sex is invalid").When(s => s != null);

            RuleFor(_ => _.YearOfBirth)
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