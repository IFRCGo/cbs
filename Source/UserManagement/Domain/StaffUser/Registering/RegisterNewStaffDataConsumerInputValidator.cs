using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewStaffDataConsumerInputValidator 
                    : NewStaffRegistrationInputValidator<RegisterNewStaffDataConsumer,Domain.StaffUser.Roles.DataConsumer>
    {
    }    
}