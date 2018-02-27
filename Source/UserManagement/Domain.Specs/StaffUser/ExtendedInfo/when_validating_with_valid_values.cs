using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;
using Concepts;

namespace Domain.Specs.StaffUser.ExtendedInfo
{
    [Subject(typeof(ExtendedInfoValidator))]
    public class when_validating_with_valid_values_including_optionsals
    {
        static ExtendedInfoValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.ExtendedInfo extended;

        Establish context = () =>
        {
            validator = new ExtendedInfoValidator();
            extended = given.extended_info.build_valid_instance();
            extended.YearOfBirth = 1980;
            extended.Sex = Sex.Female;
        };

        Because of = () => { validation_results = validator.Validate(extended); };

        It should_be_valid = () => validation_results.ShouldBeValid();          
    }
}