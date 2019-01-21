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
                .SetValidator(new DataCollectorIdValidator());
                
            RuleFor(_ => _.FullName)
                .SetValidator(new FullNameValidator());

            RuleFor(_ => _.DisplayName)
                .SetValidator(new DisplayNameValidator());

            RuleFor(_ => _.Sex)
                .IsInEnum().WithMessage("Sex is invalid").When(s => s != null);

            RuleFor(_ => _.YearOfBirth)
                .SetValidator(new YearOfBirthValidator());
            
            RuleFor(_ => _.District)
                .SetValidator(new DistrictValidator());

            RuleFor(_ => _.Region)
                .SetValidator(new RegionValidator());

        }
    }
    
}