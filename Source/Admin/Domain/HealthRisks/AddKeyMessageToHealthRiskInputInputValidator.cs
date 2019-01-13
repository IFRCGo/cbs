/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.HealthRisks
{
    public class AddKeyMessageToHealthRiskInputInputValidator : CommandInputValidatorFor<AddKeyMessageToHealthRisk>
    {
        public AddKeyMessageToHealthRiskInputInputValidator()
        {
            RuleFor(_ => _.KeyMessage)
                .NotNull()
                .WithMessage("Keymessage is required");

            RuleFor(_ => _.KeyMessage.Message)
                .NotNull()
                .NotEmpty()
                .WithMessage("Message on keymessage is required");

            RuleFor(_ => _.KeyMessage.Language)
                .NotNull()
                .NotEmpty()
                .WithMessage("Language on keymessage is required");
        }
    }
}