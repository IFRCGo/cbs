/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Dolittle.Events;
using Dolittle.Runtime.Commands;
using Dolittle.Runtime.Commands.Coordination;
using Dolittle.Runtime.Events;
using Dolittle.Runtime.Execution;
using Dolittle.Runtime.Transactions;

namespace Infrastructure.Logging
{
    public class NullCommandContext : ICommandContext
    {
        public TransactionCorrelationId TransactionCorrelationId => Guid.Empty;

        public CommandRequest Command => throw new NotImplementedException();

        public IExecutionContext ExecutionContext => throw new NotImplementedException();

        public void Commit()
        {
        }

        public void Dispose()
        {
        }

        public IEnumerable<IEventSource> GetObjectsBeingTracked()
        {
            return new IEventSource[0];
        }

        public void RegisterForTracking(IEventSource eventSource)
        {
        }

        public void Rollback()
        {
        }
    }
}