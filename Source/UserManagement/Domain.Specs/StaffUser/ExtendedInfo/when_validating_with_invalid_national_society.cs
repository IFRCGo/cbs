using System;
using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;

namespace Domain.Specs.StaffUser.ExtendedInfo
{
    [Subject(typeof(ExtendedInfoValidator))]
    public class when_validating_with_invalid_national_society
    {
        static ExtendedInfoValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.ExtendedInfo sut;

        Establish context = () =>
        {
            validator = new ExtendedInfoValidator();
            sut = given.extended_info.build_instance_with(ei => ei.NationalSociety = Guid.Empty);
            sut.YearOfBirth = 1980;
            sut.Sex = Sex.Female;
        };

        Because of = () => { validation_results = validator.Validate(sut); };

        It should_be_invalid = () => validation_results.ShouldBeInvalid();    
        It should_have_one_error = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_identify_national_society_as_the_error = () => validation_results.ShouldHaveInvalidProperty(nameof(sut.NationalSociety));      
    }
}