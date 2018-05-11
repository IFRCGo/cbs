using Dolittle.ReadModels;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read
{
    public interface IMongoDbClassMap<T>
        where T : IReadModel
    {
        void Map(BsonClassMap<T> cm);
        void Register();
    }
}