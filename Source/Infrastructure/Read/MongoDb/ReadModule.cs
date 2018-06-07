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
        readonly IImplementationsOf<IReadModel> _readModels;

        public ReadModule(IImplementationsOf<IReadModel> readModels, ITypeFinder typeFinder)
        {
            _readModels = readModels;

            var customClassMapTypes = typeFinder.FindMultiple(typeof(IBsonClassMapForReadModel<>));
            var readModelHasCustomClassMap = GetHasCustomClassMapDictionary(customClassMapTypes.ToList());

            RegisterBsonClassMaps(readModelHasCustomClassMap);

        }

        Dictionary<Type, Type> GetHasCustomClassMapDictionary(IList<Type> customClassMapTypes)
        {
            var readModelHasCustomClassMap = new Dictionary<Type, Type>();
            foreach (var readModel in _readModels)
            {
                var customClassMaps = GetCustomClassMapsForReadModel(customClassMapTypes, readModel);
                
                var customClassMap = customClassMaps.Count() > 1 
                    ? customClassMaps.FirstOrDefault(t => TypeImplementsIBsonClassMapForReadModel(t, readModel)) 
                    : customClassMaps.FirstOrDefault();

                readModelHasCustomClassMap.Add(readModel, customClassMap);
            }

            return readModelHasCustomClassMap;
        }

        static void RegisterBsonClassMaps(Dictionary<Type, Type> readModelHasCustomClassMap)
        {
            foreach (var pair in readModelHasCustomClassMap)
            {
                if (pair.Value == null)
                    BsonClassMap.LookupClassMap(pair.Key);
                else
                {
                    if (!(Activator.CreateInstance(pair.Value) is ICanRegisterBsonClassMap customClassMap))
                    {
                        throw new CustomBsonClassMapRegistratorNotProvided(
                            "There isn't provided a custom BsonClassMap registrator class that implements " + typeof(ICanRegisterBsonClassMap).FullName
                            + " for " + pair.Key.FullName);
                    }
                    if (!customClassMap.IsRegistered())
                        customClassMap.Register();
                }
            }
        }

        static IList<Type> GetCustomClassMapsForReadModel(IEnumerable<Type> customClassMapTypes, Type readModel)
        {
            return customClassMapTypes.Where(
                t => t.IsClass
                     && (TypeImplementsIBsonClassMapForReadModel(t, readModel)
                         || readModel.IsSubclassOf(GetReadModelFromIBsonClassMapFor(t)))
            ).ToList();
        }

        static bool TypeImplementsIBsonClassMapForReadModel(Type customClassMapType, Type readModel)
        {
            return GetReadModelFromIBsonClassMapFor(customClassMapType) == readModel;
        }
        static Type GetReadModelFromIBsonClassMapFor(Type customClassMapType)
        {
            return customClassMapType.GetInterface(typeof(IBsonClassMapForReadModel<>).Name).GetGenericArguments()
                .FirstOrDefault();
        }
        
    }
}