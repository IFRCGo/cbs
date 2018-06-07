using Dolittle.ReadModels;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read.MongoDb
{
    public interface IBsonClassMapForReadModel<T> : ICanRegisterBsonClassMap
        where T : IReadModel
    {
        void Map(BsonClassMap<T> cm);
    }
}