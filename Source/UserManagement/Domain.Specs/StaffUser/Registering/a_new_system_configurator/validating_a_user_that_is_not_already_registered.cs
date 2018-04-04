using Machine.Specifications;
using Domain.StaffUser;
using Domain.StaffUser.Registering;
using FluentValidation.Results;

namespace Domain.Specs.StaffUser.Registering.a_new_system_configurator
{
    [Subject("Registering")]
    public class validating_a_user_that_is_not_already_registered
    {
        static RegisterNewSystemConfigurator register;
        static RegisterNewSystemConfiguratorBusinessRulesValidator sut;
        static StaffUserIsRegistered staff_user_is_registered;
        static CanAssignToNationalSociety can_assign_to_national_society;
        static ValidationResult validation_results;

        Establish context = () => 
        {
            register = given.commands.build_valid_instance<RegisterNewSystemConfigurator>();

            staff_user_is_registered = (id) => false;
            can_assign_to_national_society = (id) => true;
            var is_new_registration = true;
            sut = new RegisterNewSystemConfiguratorBusinessRulesValidator(staff_user_is_registered, can_assign_to_national_society, is_new_registration);
        };

        Because of = () => validation_results = sut.Validate(register);

        It should_be_valid = () => validation_results.ShouldBeValid();
    }   
}