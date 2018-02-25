using System;
using Domain.DataCollectors.Commands;
using FluentValidation;

namespace Domain.DataCollectors.Validators
{
    public class UpdateDataCollectorValidator : AbstractValidator<UpdateDataCollector>
    {
        public UpdateDataCollectorValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            //TODO: Add input validation rules
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("DataCollectorId cannot be emppty")
                .NotEqual(Guid.Empty).WithMessage("DataCollectorId cannot be Guid.Empty");
        }
    }
}