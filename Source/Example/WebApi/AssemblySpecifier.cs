using doLittle.Assemblies;
using doLittle.Assemblies.Rules;

namespace WebApi
{
    public class AssemblySpecifier : ICanSpecifyAssemblies
    {
        /// <inheritdoc/>
        public void Specify(IAssemblyRuleBuilder builder)
        {
            builder.ExcludeAssembliesStartingWith(
                "Autofac",
                "System",
                "mscorlib",
                "Microsoft",
                "SQLite",
                "StackExchange",
                "Newtonsoft",
                "Remotion",
                "SOS",
                "Serilog",
                "WindowsBase",
                "netstandard"
            );
        }
    }
}