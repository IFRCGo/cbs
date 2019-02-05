/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollectors;
using Concepts.DataVerifiers;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class ChangeDataVerifierInputValidator : CommandInputValidatorFor<ChangeDataVerifier>
    {
        public ChangeDataVerifierInputValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DataCollector Id is required")
                .SetValidator(new DataCollectorIdValidator());
            RuleFor(_ => _.DataVerifierId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DataVerifier Id is required")
                .SetValidator(new DataVerifierIdValidator());
        }
    }
}
