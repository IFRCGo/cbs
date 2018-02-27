using doLittle.Runtime.Commands;
using Domain.DataCollector.Update;
using Domain.DataCollector.Add;
using Domain.DataCollector.PhoneNumber;

namespace Domain.DataCollector
{
    public interface IDataCollectorCommandHandler : ICanHandleCommands
    {
        void Handle(AddDataCollector command);
        void Handle(UpdateDataCollector command);
        void Handle(AddPhoneNumberToDataCollector command);
        void Handle(RemovePhoneNumberFromDataCollector command);
    }
}