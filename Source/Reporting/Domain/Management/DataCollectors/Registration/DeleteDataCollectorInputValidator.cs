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
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());
        }
    }
}