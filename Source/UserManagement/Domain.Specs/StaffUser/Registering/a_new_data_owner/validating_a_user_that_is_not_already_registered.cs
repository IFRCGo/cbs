using Machine.Specifications;
using Domain.StaffUser;
using Domain.StaffUser.Registering;
using System;
using FluentValidation.Results;
using given_user = Domain.Specs.StaffUser.Roles.UserInfo.given.user_info;

namespace Domain.Specs.StaffUser.Registering.a_new_data_owner
{
    [Subject("Registering")]
    public class validating_a_user_that_is_not_already_registered
    {
        static RegisterNewDataOwner register;
        static RegisterNewDataOwnerBusinessRulesValidator sut;
        static StaffUserIsRegistered staff_user_is_registered;
        static ValidationResult validation_results;
        Establish context = () => {
            register = new RegisterNewDataOwner
            {
                UserDetails = given_user.build_valid_instance()
            };

            staff_user_is_registered = (id) => false;

            sut = new RegisterNewDataOwnerBusinessRulesValidator(staff_user_is_registered);
        };

        Because of = () => validation_results = sut.Validate(register);

        It should_be_valid = () => validation_results.ShouldBeValid();
    }  
}