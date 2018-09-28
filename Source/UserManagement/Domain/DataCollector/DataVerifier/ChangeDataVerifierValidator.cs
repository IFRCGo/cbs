using Concepts.DataCollector;
using Concepts.DataVerifier;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollector.DataVerifier
{
    public class ChangeDataVerifierValidator : CommandInputValidatorFor<ChangeDataVerifier>
    {
        public ChangeDataVerifierValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());
            RuleFor(_ => _.DataVerifierId)
                .NotEmpty().WithMessage("Data Verifier Id must be set")
                .SetValidator(new DataVerifierIdValidator());
        }
    }
}
