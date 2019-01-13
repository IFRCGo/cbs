/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.AutomaticReplyMessages
{
    public class UpdateReplyMessagesConfigInputValidator : CommandInputValidatorFor<UpdateReplyMessagesConfig>
    {
        public UpdateReplyMessagesConfigInputValidator(IsTagsValid isTagsValid)
        {
            RuleFor(v => v.Messages)
                .NotNull()
                .WithMessage("Messages is missing");
            RuleFor(v => v.Messages.Keys)
                .Must(_ => isTagsValid(_))
                .WithMessage("Tags are not valid");
        }
    }
}