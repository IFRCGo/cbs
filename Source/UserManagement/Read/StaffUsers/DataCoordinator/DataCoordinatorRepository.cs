// using System;
// using Concepts;
// using Infrastructure.Read.MongoDb;
// using MongoDB.Driver;

// namespace Read.StaffUsers.DataCoordinator
// {
//     public class DataCoordinatorRepository : ExtendedReadModelRepositoryFor<Models.DataCoordinator>,
//         IDataCoordinatorRepository
//     {
//         public DataCoordinatorRepository(IMongoDatabase database) 
//             : base(database, database.GetCollection<Models.DataCoordinator>("DataCoordinators"))
//         {

//         }

//         public UpdateResult AddPhoneNumber(Guid staffUserId, string number)
//         {
//             return Update(u => u.Id ==staffUserId,
//                 Builders<Models.DataCoordinator>.Update.AddToSet(u => u.PhoneNumbers, new PhoneNumber(number)));
//         }

//         public UpdateResult RemovePhoneNumber(Guid staffUserId, string number)
//         {
//             return Update(u => u.Id == staffUserId,
//                 Builders<Models.DataCoordinator>.Update.PullFilter(u => u.PhoneNumbers, pn => pn.Value == number));
//         }

//         public UpdateResult AddAssignedNationalSociety(Guid staffUserId, Guid nationalSociety)
//         {

//             return Update(u => u.Id ==staffUserId,
//                 Builders<Models.DataCoordinator>.Update.AddToSet(u => u.AssignedNationalSocieties,nationalSociety));
//         }

//         public UpdateResult RemoveAssignedNationalSociety(Guid staffUserId, Guid nationalSociety)
//         {
//             return Update(u => u.Id == staffUserId,
//                 Builders<Models.DataCoordinator>.Update.PullFilter(u => u.AssignedNationalSocieties, ns => ns == nationalSociety));
//         }
//     }
// }