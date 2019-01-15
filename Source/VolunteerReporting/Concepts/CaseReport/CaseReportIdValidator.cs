/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.CaseReport
{
    public class CaseReportIdValidator : InputValidator<CaseReportId>
    {
        public CaseReportIdValidator()
        {
            RuleFor(_ => _.Value)
                .NotEmpty().WithMessage("Case Report It cannot be empty");
        }
    }
}