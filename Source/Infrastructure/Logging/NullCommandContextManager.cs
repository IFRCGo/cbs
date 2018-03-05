/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Runtime.Commands;

namespace Infrastructure.Logging
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