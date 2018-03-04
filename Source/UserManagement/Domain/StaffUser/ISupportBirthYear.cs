using FluentValidation;
using System;

namespace Domain.StaffUser
{

    public interface ISupportBirthYear 
    {
        int? BirthYear { get; }
    }
}