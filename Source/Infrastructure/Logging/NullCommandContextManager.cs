using doLittle.Runtime.Commands;

namespace Logging
{
    #if(false)
    public class NullCommandContextManager : ICommandContextManager
    {
        static readonly NullCommandContext NullCommandContext = new NullCommandContext();
        public bool HasCurrent => false;

        public ICommandContext EstablishForCommand(CommandRequest command)
        {
            return NullCommandContext;
        }

        public ICommandContext GetCurrent()
        {
            return NullCommandContext;
        }
    }
    #endif
}