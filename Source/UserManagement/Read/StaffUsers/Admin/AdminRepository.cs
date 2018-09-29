// using Infrastructure.Read.MongoDb;
// using MongoDB.Driver;

// namespace Read.StaffUsers.Admin
// {
//     public class AdminRepository : ExtendedReadModelRepositoryFor<Models.Admin>,
//         IAdminRepository
//     {

//         public AdminRepository(IMongoDatabase database)
//             : base(database, database.GetCollection<Models.Admin>("Admins"))
//         {
//         }
//     }
// }