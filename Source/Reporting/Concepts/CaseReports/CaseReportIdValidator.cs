/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using FluentValidation;

namespace Concepts.CaseReports
{
    public class CaseReportIdValidator : InputValidator<CaseReportId>
    {
        public CaseReportIdValidator()
        {
            RuleFor(_ => _)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("CaseReport Id must not be null")
                .NotEqual(CaseReportId.NotSet).WithMessage($"CaseReport Id must not be '{CaseReportId.NotSet.Value.ToString()}'");

        }
    }
}