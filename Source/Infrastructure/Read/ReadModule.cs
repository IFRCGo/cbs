using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dolittle.Collections;
using Dolittle.ReadModels;
using Dolittle.Reflection;
using Dolittle.Types;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read
{
    public class ReadModule : IReadModule
    {
        //public ReadModule(AppDomain appDomain)
        //{
        //    RegisterReadModelClassMaps(appDomain);
        //}

        //public void RegisterReadModelClassMaps(AppDomain appDomain)
        //{
        //    var types = appDomain.GetAssemblies().FirstOrDefault(a => a.FullName.Split(',').First() == "Read")
        //                .GetTypes();
        //    types.Where(t => t.IsClass && !t.IsAbstract && t.HasInterface(typeof(IMongoDbClassMap<>)))
        //        .ForEach(classMapType => Activator.CreateInstance(classMapType));
        //}

        private readonly IImplementationsOf<IReadModel> _readModels;
        private readonly ITypeFinder _typeFinder;

        private readonly IList<Type> _customClassMapTypes;

        public ReadModule(IImplementationsOf<IReadModel> readModels, ITypeFinder typeFinder, IInstancesOf<BsonClassMap> classMaps)
        {
            _readModels = readModels;
            _typeFinder = typeFinder;
            _customClassMapTypes = _typeFinder.FindMultiple(typeof(IMongoDbClassMapFor<>)).ToList();

            var readModelHasCustomClassMap = GetHasCustomClassMapDictionary();

            foreach (var pair in readModelHasCustomClassMap)
            {
                if (pair.Value == null)
                    BsonClassMap.LookupClassMap(pair.Key);
                else
                {
                    var customClassMap = Activator.CreateInstance(pair.Value) as dynamic;
                    if (!customClassMap.IsRegistered())
                        customClassMap.Register();
                }
            }
        }

        private Dictionary<Type, Type> GetHasCustomClassMapDictionary()
        {
            var readModelHasCustomClassMap = new Dictionary<Type, Type>();
            foreach (var readModel in _readModels)
            {
                var customClassMaps = _customClassMapTypes.Where(
                    t => t.IsClass
                         && (TypeHasIMongoDbClassMapForReadModel(t, readModel)
                             || readModel.IsSubclassOf(GetReadModelFromIMongoDbClassMapFor(t)))
                ).ToList();

                // In a polymorphic IReadModel structure, we want to take the BsonClassMap "closest to the root"
                var customClassMap = customClassMaps.Count() > 1 
                    ? customClassMaps.FirstOrDefault(t => GetReadModelFromIMongoDbClassMapFor(t) == readModel) 
                    : customClassMaps.FirstOrDefault();

                readModelHasCustomClassMap.Add(readModel, customClassMap);
            }

            return readModelHasCustomClassMap;
        }

        private Type GetReadModelFromIMongoDbClassMapFor(Type customClassMapType)
        {
            return customClassMapType.GetInterface(typeof(IMongoDbClassMapFor<>).Name).GetGenericArguments()
                .FirstOrDefault();
        }
        private bool TypeHasIMongoDbClassMapForReadModel(Type customClassMapType, Type readModel)
        {
            return GetReadModelFromIMongoDbClassMapFor(customClassMapType) == readModel;
        }
    }
}