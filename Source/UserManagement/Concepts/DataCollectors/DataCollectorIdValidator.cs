using Dolittle.Validation;
using FluentValidation;

namespace Concepts.DataCollectors
{
    public class DataCollectorIdValidator : InputValidator<DataCollectorId>
    {
        public DataCollectorIdValidator()
        {
            RuleFor(id => id.Value)
                .NotEmpty().WithMessage("Data Collector Id cannot be empty");
        }
    }
}