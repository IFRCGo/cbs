
using Microsoft.AspNetCore.Http;

namespace Core.Security
{
    public interface ISecurityBypassingRequestManager
    {
        bool ShouldBypassSecurity(HttpContext httpContext);
    }
}