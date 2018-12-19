/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollector;
using Domain.DataCollectors.Changing;

namespace Domain.DataCollectors
{
    public interface IDataCollectorRules
    {
        bool DataCollectorIsRegistered(DataCollectorId id);

        bool DataCollectorDisplayNameRegistered(string displayName);

        bool DataCollectorCanChangeDisplayName(ChangeBaseInformation command);
    }
}