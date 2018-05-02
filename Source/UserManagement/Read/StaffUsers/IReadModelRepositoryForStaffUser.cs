using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dolittle.ReadModels;
using MongoDB.Driver;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    public interface IReadModelRepositoryForStaffUser<T> : IReadModelRepositoryFor<T>
        where T : BaseUser
    {
        T Get(Guid staffUserId);
        Task<T> GetAsync(Guid staffUserId);

        Task InsertAsync(T readModel);

        Task UpdateAsync(T readModel);

        Task DeleteAsync(T readModel);

        UpdateResult UpdateOne(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        UpdateResult UpdateOne(FilterDefinition<T> predicate, UpdateDefinition<T> update);
        Task<UpdateResult> UpdateOneAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        Task<UpdateResult> UpdateOneAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update);

        UpdateResult UpdateMany(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        UpdateResult UpdateMany(FilterDefinition<T> predicate, UpdateDefinition<T> update);
        Task<UpdateResult> UpdateManyAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        Task<UpdateResult> UpdateManyAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update);

        UpdateResult ChangeBaseUserInformation(Guid staffUserId, string fullName, string displayName,
            string email);
        Task<UpdateResult> ChangeBaseUserInformationAsync(Guid staffUserId, string fullName, string displayName,
            string email);


    }
}