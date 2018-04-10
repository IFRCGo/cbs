using Machine.Specifications;
using Domain.StaffUser;
using Domain.StaffUser.Registering;
using FluentValidation.Results;

namespace Domain.Specs.StaffUser.Registering.a_new_data_owner
{
    [Subject("Registering")]
    public class validating_a_user_that_is_not_already_registered
    {
        static RegisterNewDataOwner register;
        static RegisterNewDataOwnerBusinessRulesValidator sut;
        static StaffUserIsRegistered staff_user_is_registered;
        static ValidationResult validation_results;

        private Establish context = () => {
            register = given.commands.build_valid_instance<RegisterNewDataOwner>();

            staff_user_is_registered = (id) => false;
            var is_new_registration = true;

            sut = new RegisterNewDataOwnerBusinessRulesValidator(staff_user_is_registered, is_new_registration);
        };

        Because of = () => validation_results = sut.Validate(register);

        It should_be_valid = () => validation_results.ShouldBeValid();
    }  
}