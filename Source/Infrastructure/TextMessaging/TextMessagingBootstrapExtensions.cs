using Autofac;
using Infrastructure.TextMessaging.Gateway;
using Infrastructure.TextMessaging.Modules;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.TextMessaging
{
    public static class TextMessagingBootstrapExtensions
    {
        public static IApplicationBuilder EnableSmsGatewayListner(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService(typeof(GatewayMessageReceiver));
            return app;
        }

        public static ContainerBuilder RegisterSmsGateway(this ContainerBuilder builder, bool enableLoopBackSms)
        {
            builder.RegisterModule<GatewaySenderModule>();

            if (enableLoopBackSms)
                builder.RegisterModule<GatewayLoopbackRecivedModule>();
            else
                builder.RegisterModule<GatewayReceiverModule>();
            return builder;
        }
    }
}