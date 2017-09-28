using System.Collections.Generic;
using System.Reflection;
using Infrastructure.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.AspNet
{
    internal class Internals
    {
        public static IConfiguration Configuration;
        public static ILoggerFactory LoggerFactory;
        public static IEnumerable<Assembly> Assemblies;
        public static BoundedContext BoundedContext;
    }
}