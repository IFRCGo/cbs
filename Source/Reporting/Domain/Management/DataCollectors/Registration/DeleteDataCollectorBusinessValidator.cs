using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Management.DataCollectors.Registration
{
    public class DeleteDataCollectorBusinessValidator : CommandBusinessValidatorFor<DeleteDataCollector>
    {
        public DeleteDataCollectorBusinessValidator(MustExist mustExist)
        {
            RuleFor(_ => _.DataCollectorId)
                .Must(_ => mustExist(_)).WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");
        }
    }
}