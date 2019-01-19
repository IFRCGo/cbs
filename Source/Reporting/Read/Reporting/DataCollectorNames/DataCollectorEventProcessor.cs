/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Concepts.DataCollectors;
using Events.Management.DataCollectors.Registration;
using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;
using Events.Management.DataCollectors.EditInformation;

namespace Read.Reporting.DataCollectors
{
    public class DataCollectorEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<ListedDataCollector> _dataCollectors;

        public DataCollectorEventProcessor(IReadModelRepositoryFor<ListedDataCollector> dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }
        [EventProcessor("e5772c2d-2891-4abe-ac62-1adadc353f9b")]
        public void Process(DataCollectorRegistered @event)
        {
            _dataCollectors.Insert(new ListedDataCollector(@event.DataCollectorId)
            {
                DisplayName = @event.DisplayName,
                Region = @event.Region,
                District = @event.District,
                Village = "",
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude)      
            });
        }
        [EventProcessor("4075fedc-1167-4be7-8b87-32d5d00b3802")]
        public void Process(DataCollectorUserInformationChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.Region = @event.Region;
            dataCollector.District = @event.District;
            dataCollector.Village = "";
            dataCollector.DisplayName = @event.DisplayName;

            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("80adcc97-a070-4b3a-a445-9e0e234c1869")]
        public void Process(DataCollectorLocationChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);

            _dataCollectors.Update(dataCollector);
        }
    }
}