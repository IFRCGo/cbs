namespace Infrastructure.Read.MongoDb
{
    public interface ICanRegisterMongoDbClassMap
    {
        void Register();
        bool IsRegistered();
    }
}