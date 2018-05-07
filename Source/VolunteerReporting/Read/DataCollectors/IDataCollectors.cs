/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Concepts;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace Read.DataCollectors
{
    public interface IDataCollectors
    {
        //TODO: 
        IEnumerable<DataCollector> GetAll();
        Task<IEnumerable<DataCollector>> GetAllAsync();

        DataCollector GetById(Guid id);

        DataCollector GetByPhoneNumber(string phoneNumber);
        DataCollectorId GetIdByPhoneNumber(string phoneNumber);

        void Save(DataCollector dataCollector);
        Task SaveAsync(DataCollector dataCollector);

        UpdateResult Update(FilterDefinition<DataCollector> filter, UpdateDefinition<DataCollector> update);
        Task<UpdateResult> UpdateAsync(FilterDefinition<DataCollector> filter, UpdateDefinition<DataCollector> update);

        void Remove(FilterDefinition<DataCollector> filter);
        void Remove(Expression<Func<DataCollector, bool>> filter);

        Task RemoveAsync(FilterDefinition<DataCollector> filter);
        Task RemoveAsync(Expression<Func<DataCollector, bool>> filter);

        UpdateResult AddPhoneNumber(FilterDefinition<DataCollector> filter, string number);
        UpdateResult AddPhoneNumber(Expression<Func<DataCollector, bool>> filter, string number);

        Task<UpdateResult> AddPhoneNumberAsync(FilterDefinition<DataCollector> filter, string number);
        Task<UpdateResult> AddPhoneNumberAsync(Expression<Func<DataCollector, bool>> filter, string number);

        UpdateResult RemovePhoneNumber(FilterDefinition<DataCollector> filter, string number);
        UpdateResult RemovePhoneNumber(Expression<Func<DataCollector, bool>> filter, string number);

        Task<UpdateResult> RemovePhoneNumberAsync(FilterDefinition<DataCollector> filter, string number);
        Task<UpdateResult> RemovePhoneNumberAsync(Expression<Func<DataCollector, bool>> filter, string number);

        UpdateResult ChangeUserInformation(Guid dataCollectorId, string fullName, string displayName, string region, string district);
    }
}