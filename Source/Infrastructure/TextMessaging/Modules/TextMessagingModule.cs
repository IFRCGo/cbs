using Autofac;

namespace Infrastructure.TextMessaging.Modules
{
    public class TextMessagingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new TextMessageProcessorsRegistrationSource());
        }
    }
}