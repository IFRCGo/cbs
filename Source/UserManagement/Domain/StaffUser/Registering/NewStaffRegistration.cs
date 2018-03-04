using System;
using System.Collections.Generic;
using doLittle.Commands;

namespace Domain.StaffUser.Registering
{
    public interface INewStaffRegistration : ICommand 
    {

    }
    public abstract class NewStaffRegistration<T> : INewStaffRegistration where T : Domain.StaffUser.Roles.StaffRole
    {
        public T Role { get; protected set; }
    }
}