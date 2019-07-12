using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Reporting.DataCollectors;
using System;
using System.Collections.Generic;
using System.Linq;

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
            InsertDataCollector(new DataCollector(dataCollectorId.Value, @event.RegisteredAt, @event.Region, @event.District));

            var region = _repositoryForRegion.GetById(@event.Region);
            var district = _repositoryForDistrict.GetById(@event.District);

            if (region == null)
            {
                InsertRegion(new Region()
                {
                    Id = @event.Region,
                    Name = @event.Region
                });
            }

            if (district == null)
            {
                InsertDistrict(new District()
                {
                    Id = @event.District,
                    Name = @event.District,
                    RegionName = @event.Region
                });
            }
        }

        [EventProcessor("9edadfb3-b772-09e0-1e0d-346f2b374976")]
        public void Process(DataCollectorVillageChanged @event, EventSourceId dataCollectorId)
        {
            var village = _repositoryForVillage.GetById(@event.Village);
            if (village == null)
            {
                var dataCollector = _dataCollectors.GetById(dataCollectorId);
                var district = _repositoryForDistrict.GetById(dataCollector.District);
                _repositoryForVillage.Insert(new Village()
                {
                    Id = @event.Village,
                    District = district.Name
                });
            }
        }

        public void InsertDataCollector(DataCollector dataCollector)
        {
            _dataCollectors.Insert(dataCollector);
        }

        public void InsertRegion(Region region)
        {
            _repositoryForRegion.Insert(region);
        }

        public void InsertDistrict(District district)
        {
            _repositoryForDistrict.Insert(district);
        }
    }
}
