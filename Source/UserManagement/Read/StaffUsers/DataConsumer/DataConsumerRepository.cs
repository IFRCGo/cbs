// using Infrastructure.Read.MongoDb;
// using MongoDB.Driver;

// namespace Read.StaffUsers.DataConsumer
// {
//     public class DataConsumerRepository : ExtendedReadModelRepositoryFor<Models.DataConsumer>,
//         IDataConsumerRepository
//     {
//         public DataConsumerRepository(IMongoDatabase database) 
//             : base(database, database.GetCollection<Models.DataConsumer>("DataConsumers"))
//         {
//         }
//     }
// }