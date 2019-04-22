using Concepts.CaseReports;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Reporting.CaseReports
{
    public class ConvertToTrainingReportInputValidator : CommandInputValidatorFor<ConvertToTrainingReport>
    {
        
        public ConvertToTrainingReportInputValidator() 
        {
            RuleFor(_ => _.CaseReportId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Case Report Id is required")
                .SetValidator(new CaseReportIdValidator());

        }
    }
}
