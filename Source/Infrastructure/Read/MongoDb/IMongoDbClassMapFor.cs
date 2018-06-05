using Dolittle.ReadModels;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read.MongoDb
{
    public interface IMongoDbClassMapFor<T>
        where T : IReadModel
    {
        void Map(BsonClassMap<T> cm);
        void Register();
        bool IsRegistered();
    }
}