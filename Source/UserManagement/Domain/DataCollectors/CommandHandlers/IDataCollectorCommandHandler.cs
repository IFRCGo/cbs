using doLittle.Runtime.Commands;
using Domain.DataCollectors.Commands;

namespace Domain.DataCollectors.CommandHandlers
{
    public interface IDataCollectorCommandHandler : ICanHandleCommands
    {
        void Handle(AddDataCollector command);
        void Handle(UpdateDataCollector command);
        void Handle(AddPhoneNumberToDataCollector command);
        void Handle(RemovePhoneNumberFromDataCollector command);
    }
}