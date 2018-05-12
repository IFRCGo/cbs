using Dolittle.ReadModels;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read
{
    /// <summary>
    /// All readmodels in Read should have ClassMaps that derive from this abstract class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MongoDbClassMap<T> : IMongoDbClassMap<T>
        where T : IReadModel
    {
        protected MongoDbClassMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
                BsonClassMap.RegisterClassMap<T>(Map);
        }

        public abstract void Map(BsonClassMap<T> cm);

        public abstract void Register();
    }
}