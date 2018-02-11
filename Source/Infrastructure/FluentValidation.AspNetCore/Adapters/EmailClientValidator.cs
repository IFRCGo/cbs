﻿#region License

// Copyright (c) Jeremy Skinner (http://www.jeremyskinner.co.uk)
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
// 
// http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
// 
// The latest version of this file can be found at https://github.com/jeremyskinner/FluentValidation

#endregion

using FluentValidation.Internal;
using FluentValidation.Resources;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FluentValidation.AspNetCore
{
    internal class EmailClientValidator : ClientValidatorBase
    {
        private IEmailValidator EmailValidator
        {
            get { return (IEmailValidator) Validator; }
        }

        public EmailClientValidator(PropertyRule rule, IPropertyValidator validator) : base(rule, validator)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            var formatter = new MessageFormatter().AppendPropertyName(Rule.GetDisplayName());

            string messageTemplate;
            try
            {
                messageTemplate = EmailValidator.ErrorMessageSource.GetString(null);
            }
            catch (FluentValidationMessageFormatException)
            {
                messageTemplate = ValidatorOptions.LanguageManager.GetStringForValidator<EmailValidator>();
            }

            var message = formatter.BuildMessage(messageTemplate);
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-email", message);
        }
    }
}