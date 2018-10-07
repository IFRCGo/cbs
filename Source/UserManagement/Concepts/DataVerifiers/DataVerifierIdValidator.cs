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
