using System;
using System.Linq;
using Dolittle.Collections;
using Dolittle.Reflection;

namespace Infrastructure.Read
{
    public class ReadModule : IReadModule
    {
        public ReadModule(AppDomain appDomain)
        {
            RegisterReadModelClassMaps(appDomain);
        }

        public void RegisterReadModelClassMaps(AppDomain appDomain)
        {
            var types = appDomain.GetAssemblies().FirstOrDefault(a => a.FullName.Split(',').First() == "Read")
                        .GetTypes();
            types.Where(t => t.IsClass && !t.IsAbstract && t.HasInterface(typeof(IMongoDbClassMap<>)))
                .ForEach(classMapType => Activator.CreateInstance(classMapType));
        }
    }
}