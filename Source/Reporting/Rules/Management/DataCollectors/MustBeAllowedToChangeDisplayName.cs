/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.Management.DataCollectors;

namespace Rules.Management.DataCollectors
{
    public class CanDataCollectorChangeDisplayName : IRuleImplementationFor<Domain.Management.DataCollectors.MustBeAllowedToChangeDisplayName>
    {
        readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;
        public CanDataCollectorChangeDisplayName(IReadModelRepositoryFor<DataCollector> dataCollectors) => _dataCollectors = dataCollectors;
        public Domain.Management.DataCollectors.MustBeAllowedToChangeDisplayName Rule => 
            (dataCollector, displayName) => 
                _dataCollectors.Query.SingleOrDefault(d => d.DisplayName == displayName && d.Id != dataCollector) == null;
    }
}