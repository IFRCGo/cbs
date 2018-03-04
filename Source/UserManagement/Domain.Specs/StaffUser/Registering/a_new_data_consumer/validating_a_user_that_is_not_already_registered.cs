using Machine.Specifications;
using Domain.StaffUser;
using Domain.StaffUser.Registering;
using System;
using FluentValidation.Results;
using given_user = Domain.Specs.StaffUser.Roles.UserInfo.given;

namespace Domain.Specs.StaffUser.Registering.a_new_data_consumer
{
    [Subject("Registering")]
    public class validating_a_user_that_is_not_already_registered
    {
        static RegisterNewStaffDataConsumer register;
        static RegisterNewStaffDataConsumerBusinessRulesValidator sut;
        static StaffUserIsRegistered staff_user_is_registered;
        static ValidationResult validation_results;
        Establish context = () => 
        {
            register = new RegisterNewStaffDataConsumer
            {
                UserDetails = given_user.user_info.build_valid_instance()
            };

            staff_user_is_registered = (id) => false;

            sut = new RegisterNewStaffDataConsumerBusinessRulesValidator(staff_user_is_registered);
        };

        Because of = () => validation_results = sut.Validate(register);

        It should_be_valid = () => validation_results.ShouldBeValid();
    }   
}