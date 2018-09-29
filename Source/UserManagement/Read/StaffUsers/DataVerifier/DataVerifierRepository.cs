// using System;
// using Concepts;
// using Infrastructure.Read.MongoDb;
// using MongoDB.Driver;

// namespace Read.StaffUsers.DataVerifier
// {
//     public class DataVerifierRepository : ExtendedReadModelRepositoryFor<Models.DataVerifier>,
//         IDataVerifierRepository
//     {
//         public DataVerifierRepository(IMongoDatabase database)
//             : base(database, database.GetCollection<Models.DataVerifier>("DataVerifiers"))
//         {
//         }

//         public UpdateResult AddPhoneNumber(Guid staffUserId, string number)
//         {
//             return Update(u => u.Id == staffUserId,
//                 Builders<Models.DataVerifier>.Update.AddToSet(u => u.PhoneNumbers, new PhoneNumber(number)));
//         }

//         public UpdateResult RemovePhoneNumber(Guid staffUserId, string number)
//         {
//             return Update(u => u.Id == staffUserId,
//                 Builders<Models.DataVerifier>.Update.PullFilter(u => u.PhoneNumbers, pn => pn.Value == number));
//         }

//     }
// }