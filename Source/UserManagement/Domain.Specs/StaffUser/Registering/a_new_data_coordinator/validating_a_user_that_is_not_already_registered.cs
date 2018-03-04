using Machine.Specifications;
using Domain.StaffUser;
using Domain.StaffUser.Registering;
using System;
using FluentValidation.Results;
using given_user = Domain.Specs.StaffUser.Roles.UserInfo.given.user_info;

namespace Domain.Specs.StaffUser.Registering.a_new_data_coordinator
{
    [Subject("Registering")]
    public class validating_a_user_that_is_not_already_registered
    {
        static RegisterNewDataCoordinator register;
        static RegisterNewDataCoordinatorBusinessRulesValidator sut;
        static StaffUserIsRegistered staff_user_is_registered;
        static CanAssignToNationalSociety can_assign_to_national_society;
        static ValidationResult validation_results;
        Establish context = () => 
        {
            register = new RegisterNewDataCoordinator
            {
                UserDetails = given_user.build_valid_instance(),
                AssignedNationalSocieties = new [] { Guid.NewGuid() }
            };

            staff_user_is_registered = (id) => false;
            can_assign_to_national_society = (id) => true;

            sut = new RegisterNewDataCoordinatorBusinessRulesValidator(staff_user_is_registered, can_assign_to_national_society);
        };

        Because of = () => validation_results = sut.Validate(register);

        It should_be_valid = () => validation_results.ShouldBeValid();
    } 
}