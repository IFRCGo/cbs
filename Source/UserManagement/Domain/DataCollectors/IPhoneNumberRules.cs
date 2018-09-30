namespace Domain.DataCollectors
{
    public interface IPhoneNumberRules
    {
         bool PhoneNumberIsRegistered(string number);
    }
}