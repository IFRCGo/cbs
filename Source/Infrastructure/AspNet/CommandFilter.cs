/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using doLittle.Runtime.Commands;
using doLittle.Runtime.Transactions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.AspNet
{
    public class CommandFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var commandContextManager =
                Internals.ServiceProvider.GetService(typeof(ICommandContextManager)) as ICommandContextManager;
            commandContextManager.EstablishForCommand(new CommandRequest(TransactionCorrelationId.New(), null,
                new Dictionary<string, object>()));
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var commandContextManager =
                Internals.ServiceProvider.GetService(typeof(ICommandContextManager)) as ICommandContextManager;
            if (commandContextManager.HasCurrent) commandContextManager.GetCurrent().Commit();
        }
    }
}