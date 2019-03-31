
using Microsoft.AspNetCore.Http;

namespace Core.Security
{
    public interface ICanBypassSecurity
    {
        bool ShouldBypassSecurity(HttpContext httpContext);
    }
}