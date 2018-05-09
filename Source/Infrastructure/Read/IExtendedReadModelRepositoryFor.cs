using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dolittle.ReadModels;
using MongoDB.Driver;

namespace Infrastructure.Read
{
    public interface IExtendedReadModelRepositoryFor<T> : IReadModelRepositoryFor<T>
        where T : IReadModel
    {
        #region Get

        Task<T> GetByIdAsync(object id);

        T GetOne(FilterDefinition<T> filter);
        Task<T> GetOneAsync(FilterDefinition<T> filter);
        T GetOne(Expression<Func<T, bool>> filter);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetMany(FilterDefinition<T> filter);
        Task<IEnumerable<T>> GetManyAsync(FilterDefinition<T> filter);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> filter);

        #endregion

        #region Save

        void Save(T readModel);
        void Save(T readModel, object id);
        void Save(T readModel, FilterDefinition<T> filter);
        void Save(T readModel, Expression<Func<T, bool>> filter);

        Task SaveAsync(T readModel);
        Task SaveAsync(T readModel, object id);
        Task SaveAsync(T readModel, FilterDefinition<T> filter);
        Task SaveAsync(T readModel, Expression<Func<T, bool>> filter);

        #endregion

        #region Replace

        ReplaceOneResult ReplaceOne(T readModel);
        ReplaceOneResult ReplaceOne(T readModel, object id);
        ReplaceOneResult ReplaceOne(T readModel, FilterDefinition<T> filter);
        ReplaceOneResult ReplaceOne(T readModel, Expression<Func<T, bool>> filter);

        Task<ReplaceOneResult> ReplaceOneAsync(T readModel);
        Task<ReplaceOneResult> ReplaceOneAsync(T readModel, object id);
        Task<ReplaceOneResult> ReplaceOneAsync(T readModel, FilterDefinition<T> filter);
        Task<ReplaceOneResult> ReplaceOneAsync(T readModel, Expression<Func<T, bool>> filter);

        #endregion

        // This part is just for providing async equivalents to the methods in IReadModelRepositoryFor<>
        Task InsertAsync(T readModel);
        Task UpdateAsync(T readModel);
        Task DeleteAsync(T readModel);


        #region Update

        void Update(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        void Update(FilterDefinition<T> predicate, UpdateDefinition<T> update);
        Task UpdateAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        Task UpdateAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update);


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

        /// <summary>
        /// Deletes a single Documents with the given id
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);
        /// <summary>
        /// Deletes multiple Documents matching the predicate
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Deletes multiple Documents matching the filter predicate
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(FilterDefinition<T> predicate);
        /// <summary>
        /// Deletes a single Documents with the given id
        /// </summary>
        /// <param name="id"></param>
        Task DeleteAsync(object id);
        /// <summary>
        /// Deletes multiple Documents matching the predicate
        /// </summary>
        /// <param name="predicate"></param>
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Deletes multiple Documents matching the filter predicate
        /// </summary>
        /// <param name="predicate"></param>
        Task DeleteAsync(FilterDefinition<T> predicate);

        
        DeleteResult DeleteOne(object id);
        DeleteResult DeleteOne(Expression<Func<T, bool>> predicate);
        DeleteResult DeleteOne(FilterDefinition<T> predicate);
        Task<DeleteResult> DeleteOneAsync(object id);
        Task<DeleteResult> DeleteOneAsync(Expression<Func<T, bool>> predicate);
        Task<DeleteResult> DeleteOneAsync(FilterDefinition<T> predicate);

        DeleteResult DeleteMany(Expression<Func<T, bool>> predicate);
        DeleteResult DeleteMany(FilterDefinition<T> predicate);
        Task<DeleteResult> DeleteManyAsync(Expression<Func<T, bool>> predicate);
        Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> predicate);

        #endregion

    }
}