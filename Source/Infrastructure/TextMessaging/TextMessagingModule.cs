using Autofac;

namespace Infrastructure.TextMessaging
{
    public class TextMessagingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new TextMessageProcessorsRegistrationSource());
        }
    }
}