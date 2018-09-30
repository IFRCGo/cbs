using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class ChangeBaseInformationBusinessValidator : CommandBusinessValidatorFor<ChangeBaseInformation>
    {
        public ChangeBaseInformationBusinessValidator(DataCollectorExists dataCollectorExists, CanDataCollectorChangeDisplayName beAbleToChangeDisplayName)
        {
            RuleFor(_ => _.DataCollectorId)
                .Must(dataCollector => dataCollectorExists(dataCollector))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");

            ModelRule()
                .Must(_ => beAbleToChangeDisplayName(_.DataCollectorId, _.DisplayName))
                .WithMessage(_ => $"Datacollector display name {_.DisplayName} is already taken, choose another");
        }
    }
}