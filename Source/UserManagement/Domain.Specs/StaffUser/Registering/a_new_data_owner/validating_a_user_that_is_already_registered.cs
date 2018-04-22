using Machine.Specifications;
using Domain.StaffUser;
using Domain.StaffUser.Registering;
using FluentValidation.Results;

namespace Domain.Specs.StaffUser.Registering.a_new_data_owner
{
    [Subject("Registering")]
    public class validating_a_user_that_is_already_registered
    {
        static RegisterNewDataOwner register;
        static RegisterNewDataOwnerBusinessRulesValidator sut;
        static StaffUserIsRegistered staff_user_is_registered;
        static ValidationResult validation_results;

        Establish context = () => {
            register = given.commands.build_valid_instance<RegisterNewDataOwner>();

            staff_user_is_registered = (id) => true;
            var is_new_registration = true;
            sut = new RegisterNewDataOwnerBusinessRulesValidator(staff_user_is_registered, is_new_registration);
        };

        Because of = () => validation_results = sut.Validate(register);

        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_indicate_that_the_staff_user_id_is_invalid = () => validation_results.ShouldHaveInvalidProperty($"{nameof(register.Role)}.{nameof(register.Role.StaffUserId)}");
    }
}