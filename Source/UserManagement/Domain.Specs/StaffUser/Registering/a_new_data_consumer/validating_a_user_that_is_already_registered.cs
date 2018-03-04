using Machine.Specifications;
using Domain.StaffUser;
using Domain.StaffUser.Registering;
using System;
using FluentValidation.Results;
using given = Domain.Specs.StaffUser.UserInfo.given;

namespace Domain.Specs.StaffUser.Registering.a_new_data_consumer
{
    [Subject("Registering")]
    public class validating_a_user_that_is_already_registered
    {
        static RegisterNewStaffDataConsumer register;
        static RegisterNewStaffDataConsumerBusinessRulesValidator sut;
        static StaffUserIsRegistered staff_user_is_registered;
        static ValidationResult validation_results;
        Establish context = () => 
        {
            register = new RegisterNewStaffDataConsumer
            {
                UserDetails = given.user_info.build_valid_instance(),
            };

            staff_user_is_registered = (id) => true;

            sut = new RegisterNewStaffDataConsumerBusinessRulesValidator(staff_user_is_registered);
        };

        Because of = () => validation_results = sut.Validate(register);

        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_have_one_invalidation = () => validation_results.ShouldHaveInvalidCountOf(1);
        It should_indicate_that_the_staff_user_id_is_invalid = () => validation_results.ShouldHaveInvalidProperty($"{nameof(register.UserDetails)}.{nameof(register.UserDetails.StaffUserId)}");
    }
}