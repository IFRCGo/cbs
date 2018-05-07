using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dolittle.ReadModels;
using MongoDB.Driver;

namespace Read
{
    public interface IGenericReadModelRepositoryFor<T, in TId> : IReadModelRepositoryFor<T>
        where TId : IEquatable<TId>
        where T : IReadModel, IHaveReadModelIdOf<TId>
    {
        #region Get

        T Get(TId id);
        Task<T> GetAsync(TId id);
        
        T GetOne(FilterDefinition<T> filter);
        Task<T> GetOneAsync(FilterDefinition<T> filter);
        T GetOne(Expression<Func<T, bool>> filter);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetMany(FilterDefinition<T> filter);
        Task<IEnumerable<T>> GetManyAsync(FilterDefinition<T> filter);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> filter);

        #endregion

        void Save(T readModel);
        Task SaveAsync(T readModel);

        Task InsertAsync(T readModel);
        Task UpdateAsync(T readModel);
        Task DeleteAsync(T readModel);
        /// <summary>
        /// Same as Update, just returns a ReplaceOneResult
        /// </summary>
        /// <param name="readModel"></param>
        /// <returns></returns>
        ReplaceOneResult ReplaceOne(T readModel);
        /// <summary>
        /// Same as UpdateAsync, just returns a ReplaceOneResult
        /// </summary>
        /// <param name="readModel"></param>
        /// <returns></returns>
        Task<ReplaceOneResult> ReplaceOneAsync(T readModel);

        #region Update

        UpdateResult UpdateOne(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        UpdateResult UpdateOne(FilterDefinition<T> predicate, UpdateDefinition<T> update);
        Task<UpdateResult> UpdateOneAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        Task<UpdateResult> UpdateOneAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update);

        UpdateResult UpdateMany(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        UpdateResult UpdateMany(FilterDefinition<T> predicate, UpdateDefinition<T> update);
        Task<UpdateResult> UpdateManyAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        Task<UpdateResult> UpdateManyAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update);

        #endregion

        #region Delete

        DeleteResult DeleteOne(TId id);
        Task<DeleteResult> DeleteOneAync(TId id);

        DeleteResult DeleteOne(Expression<Func<T, bool>> predicate);
        DeleteResult DeleteOne(FilterDefinition<T> predicate);
        Task<DeleteResult> DeleteOneAync(Expression<Func<T, bool>> predicate);
        Task<DeleteResult> DeleteOneAsync(FilterDefinition<T> predicate);

        DeleteResult DeleteMany(Expression<Func<T, bool>> predicate);
        DeleteResult DeleteMany(FilterDefinition<T> predicate);
        Task<DeleteResult> DeleteManyAsync(Expression<Func<T, bool>> predicate);
        Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> predicate);

        #endregion

    }
}