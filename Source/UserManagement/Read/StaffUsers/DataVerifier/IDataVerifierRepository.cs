// using System;
// using Infrastructure.Read.MongoDb;
// using MongoDB.Driver;

// namespace Read.StaffUsers.DataVerifier
// {
//     public interface IDataVerifierRepository : IExtendedReadModelRepositoryFor<Models.DataVerifier>
//     {
//         UpdateResult AddPhoneNumber(Guid staffUserId, string number);
//         UpdateResult RemovePhoneNumber(Guid staffUserId, string number);
//     }
// }