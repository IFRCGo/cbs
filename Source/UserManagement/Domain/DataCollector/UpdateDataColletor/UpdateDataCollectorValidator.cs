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

            //TODO: We have to decide how to deal with updating.
            // 1) Should the user get a form he/she can fill out which contains all the information
            // of that datacollector in the form as default values? Or 2), should we change only 
            // the fields which are provided?
            // I would say that option 1) is better since then we don't have to have null-values in the command 
            // and event, and we don't need to check the fields for null.
            
        }
    }
}