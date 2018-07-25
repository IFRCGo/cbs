namespace Domain.DataCollector.PhoneNumber
{
    public interface IPhoneNumberRules
    {
         bool PhoneNumberIsRegistered(string number);
    }
}