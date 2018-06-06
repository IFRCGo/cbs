using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;
using Dolittle.Types;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read.MongoDb
{
    public class ReadModule : IReadModule
    {
        private readonly IImplementationsOf<IReadModel> _readModels;

        public ReadModule(IImplementationsOf<IReadModel> readModels, ITypeFinder typeFinder)
        {
            _readModels = readModels;

            var customClassMapTypes = typeFinder.FindMultiple(typeof(IMongoDbClassMapFor<>));
            var readModelHasCustomClassMap = GetHasCustomClassMapDictionary(customClassMapTypes.ToList());

            RegisterBsonClassMaps(readModelHasCustomClassMap);
            
        }

        private Dictionary<Type, Type> GetHasCustomClassMapDictionary(IList<Type> customClassMapTypes)
        {
            var readModelHasCustomClassMap = new Dictionary<Type, Type>();
            foreach (var readModel in _readModels)
            {
                var customClassMaps = GetCustomClassMapsForReadModel(customClassMapTypes, readModel);

                // In a polymorphic IReadModel structure, we want to take the BsonClassMap "closest to the root"
                var customClassMap = customClassMaps.Count() > 1 
                    ? customClassMaps.FirstOrDefault(t => TypeImplementsIMongoDbClassMapForReadModel(t, readModel)) 
                    : customClassMaps.FirstOrDefault();

                readModelHasCustomClassMap.Add(readModel, customClassMap);
            }

            return readModelHasCustomClassMap;
        }

        private static void RegisterBsonClassMaps(Dictionary<Type, Type> readModelHasCustomClassMap)
        {
            foreach (var pair in readModelHasCustomClassMap)
            {
                if (pair.Value == null)
                    BsonClassMap.LookupClassMap(pair.Key);
                else
                {
                    //TODO: Risky, maybe look for an alternative 
                    var customClassMap = Activator.CreateInstance(pair.Value) as dynamic;
                    if (!customClassMap.IsRegistered())
                        customClassMap.Register();
                }
            }
        }

        private static IList<Type> GetCustomClassMapsForReadModel(IEnumerable<Type> customClassMapTypes, Type readModel)
        {
            return customClassMapTypes.Where(
                t => t.IsClass
                     && (TypeImplementsIMongoDbClassMapForReadModel(t, readModel)
                         || readModel.IsSubclassOf(GetReadModelFromIMongoDbClassMapFor(t)))
            ).ToList();
        }
        private static bool TypeImplementsIMongoDbClassMapForReadModel(Type customClassMapType, Type readModel)
        {
            return GetReadModelFromIMongoDbClassMapFor(customClassMapType) == readModel;
        }
        private static Type GetReadModelFromIMongoDbClassMapFor(Type customClassMapType)
        {
            return customClassMapType.GetInterface(typeof(IMongoDbClassMapFor<>).Name).GetGenericArguments()
                .FirstOrDefault();
        }
        
    }
}