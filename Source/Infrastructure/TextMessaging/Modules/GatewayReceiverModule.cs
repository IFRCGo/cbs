using Autofac.Core;
using Autofac;
using doLittle.Logging;
using Infrastructure.TextMessaging.Gateway;
using Microsoft.Extensions.Options;

namespace Infrastructure.TextMessaging.Modules
{
    internal class GatewayReceiverModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GatewayMessageReceiver>()
                .WithParameters(new Parameter[]
                {
                    new ResolvedParameter((p,ctx)=> ctx.GetType() == typeof(GatewaySettings),(p,ctx)=> ctx.Resolve<IOptions<GatewaySettings>>().Value),
                    new ResolvedParameter((p,ctx)=> ctx.GetType() == typeof(ILogger),(p,ctx)=> ctx.Resolve<ILogger>()),
                    new ResolvedParameter((p,ctx)=> ctx.GetType() == typeof(ITextMessageProcessors),(p,ctx)=> ctx.Resolve<ITextMessageProcessors>())
                })
                .SingleInstance();
        }
    }
}