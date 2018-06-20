/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Concepts;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;
using Concepts.DataCollector;

namespace Read.DataCollectors
{
    public interface IDataCollectors : IExtendedReadModelRepositoryFor<DataCollector>
    {
        //TODO: 
        IEnumerable<DataCollector> GetAll();
        DataCollector GetById(DataCollectorId id);

        DataCollector GetByPhoneNumber(string phoneNumber);
        DataCollectorId GetIdByPhoneNumber(string phoneNumber);

        void SaveDataCollector(DataCollectorId dataCollectorId, string fullName, string displayName, double locationLatitude, double locationLongitude, string region, string district);
        UpdateResult AddPhoneNumber(FilterDefinition<DataCollector> filter, string number);
        UpdateResult AddPhoneNumber(Expression<Func<DataCollector, bool>> filter, string number);

        UpdateResult RemovePhoneNumber(FilterDefinition<DataCollector> filter, string number);
        UpdateResult RemovePhoneNumber(Expression<Func<DataCollector, bool>> filter, string number);

        UpdateResult ChangeUserInformation(DataCollectorId dataCollectorId, string fullName, string displayName, string region, string district);

        UpdateResult ChangeLocation(DataCollectorId dataCollectorId, double latitude, double longitude);
    }
}