using Autofac;
using Autofac.Core;
using doLittle.Logging;
using Infrastructure.TextMessaging.Gateway;
using Microsoft.Extensions.Options;

namespace Infrastructure.TextMessaging.Modules
{
    internal class GatewayLoopbackRecivedModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GatewayMessageSenderLoopback>()
                .WithParameters(new Parameter[]
                {
                    new ResolvedParameter((p,ctx)=> ctx.GetType() == typeof(GatewaySettings),(p,ctx)=> ctx.Resolve<IOptions<GatewaySettings>>().Value),
                    new ResolvedParameter((p,ctx)=> ctx.GetType() == typeof(ILogger),(p,ctx)=> ctx.Resolve(typeof(ILogger))),
                })
                .As<ISendSms>()
                .SingleInstance();
        }
    }
}