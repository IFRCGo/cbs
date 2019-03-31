using System.Linq;
using Dolittle.DependencyInversion;
using Dolittle.Lifecycle;
using Dolittle.Types;
using Microsoft.AspNetCore.Http;

namespace Core.Security
{
    [Singleton]
    public class BypassControllersManager : ISecurityBypassingRequestManager
    {
        readonly IImplementationsOf<ICanBypassSecurity> _securityBypassers;
        readonly IContainer _container;

        public BypassControllersManager(IImplementationsOf<ICanBypassSecurity> securityBypassers, IContainer container)
        {
            _securityBypassers = securityBypassers;
            _container = container;
        }

        public bool ShouldBypassSecurity(HttpContext httpContext)
        {
            return _securityBypassers.Any(_ => {
                var bypasser = (ICanBypassSecurity)_container.Get(_);
                return bypasser.ShouldBypassSecurity(httpContext);
            });
        }
    }
}