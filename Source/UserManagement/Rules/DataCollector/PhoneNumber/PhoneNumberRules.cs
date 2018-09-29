using Domain.DataCollector.PhoneNumber;
using Read.DataCollectors;

namespace Rules.DataCollector.PhoneNumber
{
    public class PhoneNumberRules : IPhoneNumberRules
    {
        readonly IDataCollectors _dataCollectors;

        public PhoneNumberRules(IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }

        public bool PhoneNumberIsRegistered(string number)
        {
            //TODO: Maybe consider keeping a seperate phone number collection?
            foreach (var dataCollector in _dataCollectors.GetAll())
            {
                foreach (var phoneNumber in dataCollector.PhoneNumbers)
                {
                    if (phoneNumber.Value == number)
                        return true;
                }
            }

            return false;
        }
    }
}