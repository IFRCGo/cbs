/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Read
{
    public interface IDataCollectors
    {
        DataCollector GetById(Guid id);
        DataCollector GetByPhoneNumber(string phoneNumber);
        void Save(DataCollector dataCollector);
    }
}