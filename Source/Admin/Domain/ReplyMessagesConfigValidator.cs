/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using FluentValidation;

namespace Domain
{
    public class ReplyMessagesConfigValidator : AbstractValidator<UpdateReplyMessagesConfig>
    {
        public ReplyMessagesConfigValidator(IReplyMessagesConfigRules rules)
        {
            RuleFor(v => v.Messages).NotNull().WithMessage("Messages is missing");
            RuleFor(v => v.Messages.Keys).Must(rules.IsTagsValid).WithMessage("Tags are not valid");
        }
    }
}