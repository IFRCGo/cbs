using Dolittle.DependencyInversion;

namespace Policies.Alerts
{
    public class MailSenderBinder : ICanProvideBindings
    {
        public void Provide(IBindingProviderBuilder builder)
        {
            builder.Bind<IMailSender>().To<BasicMailSender>();
        }
    }
}
