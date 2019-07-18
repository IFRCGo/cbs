/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Concepts;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Reporting.DataCollectors;

namespace Read.DataCollectors
{
    public class EventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;
        readonly IReadModelRepositoryFor<District> _repositoryForDistrict;
        readonly IReadModelRepositoryFor<Region> _repositoryForRegion;
        readonly IReadModelRepositoryFor<Village> _repositoryForVillage;

        public EventProcessor(
            IReadModelRepositoryFor<DataCollector> dataCollectors,
            IReadModelRepositoryFor<District> repositoryForDistrict,
            IReadModelRepositoryFor<Village> repositoryForVillage,
            IReadModelRepositoryFor<Region> repositoryForRegion
        )
        {
            _dataCollectors = dataCollectors;
            _repositoryForDistrict = repositoryForDistrict;
            _repositoryForRegion = repositoryForRegion;
            _repositoryForVillage = repositoryForVillage;
        }

        [EventProcessor("882ec5be-6ad0-8d65-9e14-6b0c9ddf5922")]
        public void Process(DataCollectorRegistered @event, EventSourceId dataCollectorId)
        {
            // insert data collector
            var dataCollector = new DataCollector(
                dataCollectorId.Value,
                @event.RegisteredAt,
                @event.Region,
                @event.District,
                new Location(@event.LocationLatitude, @event.LocationLongitude));
            _dataCollectors.Insert(dataCollector);

            var region = _repositoryForRegion.Query.FirstOrDefault(_ => _.Name == @event.Region);
            var district = _repositoryForDistrict.Query.FirstOrDefault(_ => _.Name == @event.District);

            if (region == null)
            {
                // if region doesn't exist, create it
                region = new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = @event.Region
                };
                _repositoryForRegion.Insert(region);
            }

            if (district == null)
            {
                // create if doesn't exist
                district = new District()
                {
                    Id = Guid.NewGuid(),
                    Name = @event.District,
                    RegionId = region.Id
                };
                _repositoryForDistrict.Insert(district);
            }
        }

        [EventProcessor("9edadfb3-b772-09e0-1e0d-346f2b374976")]
        public void Process(DataCollectorVillageChanged @event, EventSourceId dataCollectorId)
        {
            var village = _repositoryForVillage.Query.FirstOrDefault(_ => _.Name == @event.Village);
            if (village == null)
            {
                var dataCollector = _dataCollectors.GetById(dataCollectorId);
                var district = _repositoryForDistrict.Query.FirstOrDefault(_ => _.Name == dataCollector.District);
                _repositoryForVillage.Insert(new Village()
                {
                    Id = Guid.NewGuid(),
                    Name = @event.Village,
                    DistrictId = district.Id
                });
            }
        }
    }
}
