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
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DataCollector Id is required")
                .SetValidator(new DataCollectorIdValidator());
                
            RuleFor(_ => _.FullName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("FullName is required")
                .SetValidator(new FullNameValidator());

            RuleFor(_ => _.DisplayName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DisplayName is required")
                .SetValidator(new DisplayNameValidator());

            RuleFor(_ => _.Sex)
                .IsInEnum().WithMessage("Sex is invalid").When(s => s != null);

            RuleFor(_ => _.YearOfBirth)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("YearOfBirth is required")
                .SetValidator(new YearOfBirthValidator());
            
            RuleFor(_ => _.District)

                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("District is required")
                .SetValidator(new DistrictValidator());

            RuleFor(_ => _.Region)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Region is required")
                .SetValidator(new RegionValidator());

        }
    }
    
}