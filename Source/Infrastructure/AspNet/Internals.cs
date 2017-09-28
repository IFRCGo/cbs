using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.AspNet
{
    internal class Internals
    {
        public static ILoggerFactory LoggerFactory;
        public static IEnumerable<Assembly> Assemblies;
    }
}