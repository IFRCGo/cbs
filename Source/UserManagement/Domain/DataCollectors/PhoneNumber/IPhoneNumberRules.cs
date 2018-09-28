namespace Domain.DataCollectors.PhoneNumber
{
    public interface IPhoneNumberRules
    {
         bool PhoneNumberIsRegistered(string number);
    }
}