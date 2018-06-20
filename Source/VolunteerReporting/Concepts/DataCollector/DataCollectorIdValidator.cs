using Dolittle.Validation;
using FluentValidation;

namespace Concepts.DataCollector
{
    public class DataCollectorIdValidator : InputValidator<DataCollectorId>
    {
        public DataCollectorIdValidator()
        {
            RuleFor(_ => _.Value)
                .NotEmpty().WithMessage("DataCollector Id cannot be empty");
        }
    }
}