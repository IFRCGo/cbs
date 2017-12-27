using Autofac;
using Autofac.Core;
using Infrastructure.TextMessaging.Gateway;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.TextMessaging.Modules
{
    internal class GatewaySenderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GatewayMessageSender>()
                .WithParameters(new Parameter[]
                {
                    new ResolvedParameter((p,ctx)=> ctx.GetType() == typeof(GatewaySettings),(p,ctx)=> ctx.Resolve<IOptions<GatewaySettings>>().Value),
                    new ResolvedParameter((p,ctx)=> ctx.GetType() == typeof(ILogger),(p,ctx)=> ctx.Resolve(typeof(ILogger)))
                })
                .As<ISendSms>()
                .SingleInstance();
        }
    }
}