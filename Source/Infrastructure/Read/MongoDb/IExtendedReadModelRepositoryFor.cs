using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dolittle.ReadModels;
using MongoDB.Driver;

namespace Infrastructure.Read.MongoDb
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <inheritdoc cref="IReadModelRepositoryFor{T}"/>
    public interface IExtendedReadModelRepositoryFor<T> : IReadModelRepositoryFor<T>
        where T : IReadModel
    {

        // This part is just for providing async equivalents to the methods in IReadModelRepositoryFor<>

        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T readModel);
        Task UpdateAsync(T readModel);
        Task DeleteAsync(T readModel);

        #region Get

        /// <summary>
        /// Retrieves a single document matching the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T GetOne(FilterDefinition<T> filter);
        /// <summary>
        /// Retrieves a single document matching the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<T> GetOneAsync(FilterDefinition<T> filter);
        /// <summary>
        /// Retrieves a single document matching the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T GetOne(Expression<Func<T, bool>> filter);
        /// <summary>
        /// Retrieves a single document matching the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Retrieves multiple documents matching the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<T> GetMany(FilterDefinition<T> filter);
        /// <summary>
        /// Retrieves multiple documents matching the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetManyAsync(FilterDefinition<T> filter);
        /// <summary>
        /// Retrieves multiple documents matching the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<T> GetMany(Expression<Func<T, bool>> filter);
        /// <summary>
        /// Retrieves multiple documents matching the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> filter);

        #endregion

        #region ReplaceOne

        /// <summary>
        /// Replaces a single document matching the predicate with readModel
        /// </summary>
        /// <param name="readModel"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        ReplaceOneResult ReplaceOne(T readModel, FilterDefinition<T> filter);
        /// <summary>
        /// Replaces a single document matching the predicate with readModel
        /// </summary>
        /// <param name="readModel"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        ReplaceOneResult ReplaceOne(T readModel, Expression<Func<T, bool>> filter);
        /// <summary>
        /// Replaces a single document matching the predicate with readModel
        /// </summary>
        /// <param name="readModel"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<ReplaceOneResult> ReplaceOneAsync(T readModel, FilterDefinition<T> filter);
        /// <summary>
        /// Replaces a single document matching the predicate with readModel
        /// </summary>
        /// <param name="readModel"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<ReplaceOneResult> ReplaceOneAsync(T readModel, Expression<Func<T, bool>> filter);

        #endregion

        #region Update
        
        /// <summary>
        /// Updates the documents matching the predicate by sending an UpdateDocument with the UpdateDefinition.
        /// Provides thread-safe and effective updating of documents.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="update"></param>
        UpdateResult Update(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        /// <summary>
        /// Updates the documents matching the predicate by sending an UpdateDocument with the UpdateDefinition.
        /// Provides thread-safe and effective updating of documents.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="update"></param>
        UpdateResult Update(FilterDefinition<T> predicate, UpdateDefinition<T> update);
        /// <summary>
        /// Updates the documents matching the predicate by sending an UpdateDocument with the UpdateDefinition.
        /// Provides thread-safe and effective updating of documents.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="update"></param>
        Task<UpdateResult> UpdateAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        /// <summary>
        /// Updates the documents matching the predicate by sending an UpdateDocument with the UpdateDefinition.
        /// Provides thread-safe and effective updating of documents.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="update"></param>
        Task<UpdateResult> UpdateAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update);

        #endregion

        #region Delete
        
        /// <summary>
        /// Deletes multiple Documents matching the predicate
        /// </summary>
        /// <param name="predicate"></param>
        DeleteResult Delete(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Deletes multiple Documents matching the filter predicate
        /// </summary>
        /// <param name="predicate"></param>
        DeleteResult Delete(FilterDefinition<T> predicate);
        /// <summary>
        /// Deletes multiple Documents matching the predicate
        /// </summary>
        /// <param name="predicate"></param>
        Task<DeleteResult> DeleteAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Deletes multiple Documents matching the filter predicate
        /// </summary>
        /// <param name="predicate"></param>
        Task<DeleteResult> DeleteAsync(FilterDefinition<T> predicate);

        #endregion
    }
}