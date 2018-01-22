using System;
using doLittle.Runtime.Commands;

namespace Logging
{
    public class NullCommandContextManager : ICommandContextManager
    {
        public bool HasCurrent => false;

        public ICommandContext EstablishForCommand(CommandRequest command)
        {
            throw new NotImplementedException();
        }

        public ICommandContext GetCurrent()
        {
            throw new NotImplementedException();
        }
    }
}