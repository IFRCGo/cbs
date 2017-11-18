using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Domain
{
    public class DefineAutomaticReplyForProjectValidator : AbstractValidator<DefineAutomaticReplyForProject>
    {
        public DefineAutomaticReplyForProjectValidator()
        {
            RuleFor(v => v.Language).Must(IsValidCultureName);
            RuleFor(v => v.ProjectId).Must(IsValidProject);
        }

        private bool IsValidProject(Guid projectId)
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
