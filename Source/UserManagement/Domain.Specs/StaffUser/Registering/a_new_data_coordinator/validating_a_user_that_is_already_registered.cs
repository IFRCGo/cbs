using Machine.Specifications;
using Domain.StaffUser;
using Domain.StaffUser.Registering;
using System;
using FluentValidation.Results;
using given_user = Domain.Specs.StaffUser.Roles.UserInfo.given.user_info;

namespace Domain.Specs.StaffUser.Registering.a_new_data_coordinator
{
    [Subject("Registering")]
    public class validating_a_user_that_is_already_registered
    {
        static RegisterNewDataCoordinator register;
        static RegisterNewDataCoordinatorBusinessRulesValidator sut;
        static StaffUserIsRegistered staff_user_is_registered;
        static CanAssignToNationalSociety can_assign_to_national_society;
        static ValidationResult validation_results;
        Establish context = () => {
            register = new RegisterNewDataCoordinator
            {
                UserDetails = given_user.build_valid_instance(),
                AssignedNationalSocieties = new [] { Guid.NewGuid() }
            };

            staff_user_is_registered = (id) => true;
            can_assign_to_national_society = (id) => true;

            sut = new RegisterNewDataCoordinatorBusinessRulesValidator(staff_user_is_registered, can_assign_to_national_society);
        };

        Because of = () => validation_results = sut.Validate(register);

        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_indicate_that_the_staff_user_id_is_invalid = () => validation_results.ShouldHaveInvalidProperty($"{nameof(register.UserDetails)}.{nameof(register.UserDetails.StaffUserId)}");
    }
}