using MongoDB.Driver;

namespace Read.StaffUsers.DataConsumer
{
    public class DataConsumerRepository : ReadModelRepositoryForStaffUser<Models.DataConsumer>,
        IDataConsumerRepository
    {
        public DataConsumerRepository(IMongoDatabase database) 
            : base(database, database.GetCollection<Models.DataConsumer>("DataConsumers"))
        {
        }
    }
}