/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.DataVerifiers
{
    public class DataVerifierIdValidator : InputValidator<DataVerifierId>
    {
        public DataVerifierIdValidator()
        {
            RuleFor(id => id.Value)
                .NotEmpty().WithMessage("Data Verifier Id cannot be empty");
        }
    }
}
