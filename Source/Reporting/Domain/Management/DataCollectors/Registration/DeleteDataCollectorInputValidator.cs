using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.Registration
{
    public class DeleteDataCollectorInputValidator : CommandInputValidatorFor<DeleteDataCollector>
    {
        public DeleteDataCollectorInputValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("DataCollector Id is required")
                .SetValidator(new DataCollectorIdValidator());
        }
    }
}