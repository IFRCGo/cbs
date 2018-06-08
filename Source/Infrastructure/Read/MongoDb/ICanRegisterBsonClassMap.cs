namespace Infrastructure.Read.MongoDb
{
    public interface ICanRegisterBsonClassMap
    {
        void Register();
        bool IsRegistered();
    }
}