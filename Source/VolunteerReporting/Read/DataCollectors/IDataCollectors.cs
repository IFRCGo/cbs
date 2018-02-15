/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Concepts;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Read.DataCollectors
{
    public interface IDataCollectors
    {
        Task<IEnumerable<DataCollector>> getAllAsync();
        DataCollector GetById(Guid id);
        DataCollector GetByPhoneNumber(string phoneNumber);
        DataCollectorId GetIdByPhoneNumber(string phoneNumber);
        Task Save(DataCollector dataCollector);
    }
}