/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Globalization;
using System.Linq;
using Concepts.Projects;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Reporting.AutomaticReplyMessages
{
    public class DefineAutomaticReplyForProjectValidator : CommandInputValidatorFor<DefineAutomaticReplyForProject>
    {
        public DefineAutomaticReplyForProjectValidator()
        {
            RuleFor(v => v.Language).Must(IsValidCultureName);
            RuleFor(v => v.ProjectId).Must(IsValidProject);
        }

        private bool IsValidProject(ProjectId projectId)
        {
            // TODO: When project read model is ready, check if this ID exists
            return true;
        }

        private bool IsValidCultureName(string language)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures).Any(culture => string.Equals(culture.Name, language, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}