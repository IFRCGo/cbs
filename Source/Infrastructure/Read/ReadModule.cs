using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;
using Dolittle.Types;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read
{
    public class ReadModule : IReadModule
    {
        private readonly IImplementationsOf<IReadModel> _readModels;

        public ReadModule(IImplementationsOf<IReadModel> readModels, ITypeFinder typeFinder)
        {
            _readModels = readModels;

            var customClassMapTypes = typeFinder.FindMultiple(typeof(IMongoDbClassMapFor<>)).ToList();

            var readModelHasCustomClassMap = GetHasCustomClassMapDictionary(customClassMapTypes);

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

        private Dictionary<Type, Type> GetHasCustomClassMapDictionary(IList<Type> customClassMapTypes)
        {
            var readModelHasCustomClassMap = new Dictionary<Type, Type>();
            foreach (var readModel in _readModels)
            {
                var customClassMaps = customClassMapTypes.Where(
                    t => t.IsClass
                         && (TypeHasIMongoDbClassMapForReadModel(t, readModel)
                             || readModel.IsSubclassOf(GetReadModelFromIMongoDbClassMapFor(t)))
                ).ToList();

                // In a polymorphic IReadModel structure, we want to take the BsonClassMap "closest to the root"
                var customClassMap = customClassMaps.Count() > 1 
                    ? customClassMaps.FirstOrDefault(t => TypeHasIMongoDbClassMapForReadModel(t, readModel)) 
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