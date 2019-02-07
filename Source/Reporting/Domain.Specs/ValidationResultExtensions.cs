/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Validation;
using System.Linq;
using System.Collections.Generic;
using Machine.Specifications;
using fv = FluentValidation.Results;

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

        public static void ShouldBeValid(this fv.ValidationResult validationResults)
        {
            validationResults.IsValid.ShouldBeTrue();
        }

        public static void ShouldBeInvalid(this fv.ValidationResult validationResults)
        {
            validationResults.IsValid.ShouldBeFalse();
        }

        public static void ShouldHaveInvalidProperty(this fv.ValidationResult validationResults, string propertyName)
        {
            validationResults.Errors.Any(r => r.PropertyName == propertyName).ShouldBeTrue();
        }

        public static void ShouldHaveInvalidNestedProperty(this fv.ValidationResult validationResults, string propertyName)
        {
            validationResults.Errors.Any(r => r.PropertyName.EndsWith(propertyName)).ShouldBeTrue();
        }

        public static void ShouldHaveInvalidCountOf(this fv.ValidationResult validationResults, int expected)
        {
            validationResults.Errors.Count().ShouldEqual(expected);
        }
    }
}