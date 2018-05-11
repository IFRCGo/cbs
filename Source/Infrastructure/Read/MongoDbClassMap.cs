using Dolittle.ReadModels;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read
{
    public abstract class MongoDbClassMap<T>
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