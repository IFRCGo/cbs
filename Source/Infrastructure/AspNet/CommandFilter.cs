using System.Collections.Generic;
using System.Threading;
using doLittle.Runtime.Commands;
using doLittle.Runtime.Transactions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.AspNet
{
    public class CommandFilter : ActionFilterAttribute
    {
        static AsyncLocal<bool> _hasEstablishedCommandContext = new AsyncLocal<bool>();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var commandContextManager = Internals.ServiceProvider.GetService(typeof(ICommandContextManager)) as ICommandContextManager;
            commandContextManager.EstablishForCommand(new CommandRequest(TransactionCorrelationId.New(),null, new Dictionary<string,object>()));
            _hasEstablishedCommandContext.Value = true;
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            if( !_hasEstablishedCommandContext.Value ) return;
            var commandContextManager = Internals.ServiceProvider.GetService(typeof(ICommandContextManager)) as ICommandContextManager;
            commandContextManager.GetCurrent().Commit();
        }
    }
}