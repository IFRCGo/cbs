using FluentValidation;

namespace Domain.DataCollectors
{
    public delegate bool PhoneNumberShouldNotBeRegistered(string number);
}