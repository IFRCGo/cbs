using doLittle.Validation;
using System.Linq;
using System.Collections.Generic;
using Machine.Specifications;

namespace Domain.Specs
{
    public static class ValidationResultExtensions
    {
        public static void ShouldBeValid(this IEnumerable<ValidationResult> validationResults)
        {
            validationResults.Any().ShouldBeFalse();
        }

        public static void ShouldBeInvalid(this IEnumerable<ValidationResult> validationResults)
        {
            validationResults.Any().ShouldBeTrue();
        }

        public static void ShouldHaveInvalidProperty(this IEnumerable<ValidationResult> validationResults, string propertyName)
        {
            validationResults.Any(r => r.MemberNames.Any(n => n == propertyName)).ShouldBeTrue();
        }

        public static void ShouldHaveInvalidCountOf(this IEnumerable<ValidationResult> validationResults, int expected)
        {
            validationResults.Count().ShouldEqual(expected);
        }
    }
}