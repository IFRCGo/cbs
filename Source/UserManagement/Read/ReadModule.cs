
using System;
using System.Linq;
using System.Reflection;
using Dolittle.Collections;
using Dolittle.ReadModels;
using Dolittle.Reflection;
using Infrastructure.Read;
using Read.StaffUsers.Models;

namespace Read
{
    public static class ReadModule
    { // TODO: This is temporary, we want to automatically discover BsonClassMaps in startup.

        public static void RegisterReadModelClassMaps()
        {
            Assembly.GetAssembly(typeof(ReadModule)).GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.HasInterface(typeof(IMongoDbClassMap<>)))
                .ForEach(classMapType => Activator.CreateInstance(classMapType));
            
        }
    }
}