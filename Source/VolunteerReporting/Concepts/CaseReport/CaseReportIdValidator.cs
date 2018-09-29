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