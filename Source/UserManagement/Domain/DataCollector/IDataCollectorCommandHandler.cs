using doLittle.Runtime.Commands;
using Domain.DataCollector.PhoneNumber;
using Domain.DataCollector.Registering;
using Domain.DataCollector.Update;

namespace Domain.DataCollector
{
    public interface IDataCollectorCommandHandler : ICanHandleCommands
    {
        void Handle(RegisterDataCollector command);

        void Handle(UpdateDataCollector command);
        void Handle(AddPhoneNumberToDataCollector command);

        void Handle(RemovePhoneNumberFromDataCollector command);
    }
}