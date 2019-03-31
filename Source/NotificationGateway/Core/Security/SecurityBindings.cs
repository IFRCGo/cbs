using Dolittle.DependencyInversion;

namespace Core.Security
{
    public class SecurityBindings : ICanProvideBindings
    {
        public void Provide(IBindingProviderBuilder builder)
        {
            builder.Bind<ISecurityBypassingRequestManager>().To<BypassControllersManager>();
        }
    }
}