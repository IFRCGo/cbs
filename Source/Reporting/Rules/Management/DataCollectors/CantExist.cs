/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.Management.DataCollectors;

namespace Rules.Management.DataCollectors
{
    public class CantExist : IRuleImplementationFor<Domain.Management.DataCollectors.CantExist>
    {
        readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;
        public CantExist(IReadModelRepositoryFor<DataCollector> dataCollectors) => _dataCollectors = dataCollectors;
        public Domain.Management.DataCollectors.CantExist Rule => (dataCollector) => _dataCollectors.GetById(dataCollector) == null;
    }
}