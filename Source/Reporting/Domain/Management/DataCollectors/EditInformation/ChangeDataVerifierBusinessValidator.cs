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
    public class ChangeDataVerifierBusinessValidator : CommandBusinessValidatorFor<ChangeDataVerifier>
    {
        public ChangeDataVerifierBusinessValidator()
        {
        }
    }
}
