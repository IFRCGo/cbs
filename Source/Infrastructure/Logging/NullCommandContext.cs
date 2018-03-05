/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using doLittle.Runtime.Commands;
using doLittle.Runtime.Events;
using doLittle.Runtime.Execution;
using doLittle.Runtime.Transactions;

namespace Logging
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