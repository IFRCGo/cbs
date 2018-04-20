using doLittle.Runtime.Commands;
using Domain.DataCollector.PhoneNumber;
using Domain.DataCollector.Registering;

namespace Domain.DataCollector
{
    public interface IDataCollectorCommandHandler : ICanHandleCommands
    {
        void Handle(RegisterDataCollector command);

        void Handle(DeleteDataCollector command);


        void Handle(AddPhoneNumberToDataCollector command);

        void Handle(RemovePhoneNumberFromDataCollector command);
    }
}