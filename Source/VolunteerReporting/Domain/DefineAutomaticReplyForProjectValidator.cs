using System;
using System.Globalization;
using System.Linq;
using Concepts;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain
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