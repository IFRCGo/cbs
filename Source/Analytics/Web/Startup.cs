
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Web
{
    public class Startup : Infrastructure.AspNet.Startup
    {
        public Startup(
            ILoggerFactory loggerFactory,
            IHostingEnvironment env,
            IConfiguration configuration) : base(loggerFactory, env, configuration)
        { }
    }
}