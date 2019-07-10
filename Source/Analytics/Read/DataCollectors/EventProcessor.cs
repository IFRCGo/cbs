using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Admin.DataCollectors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Read.DataCollectors
{
    public class EventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<District> _repositoryForDistrict;
        readonly IReadModelRepositoryFor<Region> _repositoryForRegion;
        readonly IReadModelRepositoryFor<Village> _repositoryForVillage;

        public EventProcessor(
            IReadModelRepositoryFor<District> repositoryForDistrict,
            IReadModelRepositoryFor<Village> repositoryForVillage,
            IReadModelRepositoryFor<Region> repositoryForRegion
        )
        {
            _repositoryForDistrict = repositoryForDistrict;
            _repositoryForRegion = repositoryForRegion;
            _repositoryForVillage = repositoryForVillage;
        }

        [EventProcessor("882ec5be-6ad0-8d65-9e14-6b0c9ddf5922")]
        public void Process(DataCollectorRegistered @event, EventSourceId dataCollectorId)
        {
            var region = _repositoryForRegion.GetById(@event.Region);
            var district = _repositoryForDistrict.GetById(@event.District);

            if (region == null)
            {
                _repositoryForRegion.Insert(new Region()
                {
                    Id = @event.Region,
                    Name = @event.Region
                });
            }

            if (district == null)
            {
                _repositoryForDistrict.Insert(new District()
                {
                    Id = @event.District,
                    Name = @event.District,
                    RegionName = @event.Region,
                    DataCollectors = new List<Guid>(){ dataCollectorId }
                });
            }
            else 
            {
                district.DataCollectors.Add(dataCollectorId);
                _repositoryForDistrict.Update(district);
            }
        }

        [EventProcessor("9edadfb3-b772-09e0-1e0d-346f2b374976")]
        public void Process(DataCollectorVillageChanged @event, EventSourceId dataCollectorId)
        {
            var village = _repositoryForVillage.GetById(@event.Village);
            if (village == null)
            {
                var district = _repositoryForDistrict.Query.FirstOrDefault(_ => _.DataCollectors.Contains(dataCollectorId));
                _repositoryForVillage.Insert(new Village()
                {
                    Id = @event.Village,
                    District = district.Name
                });
            }
        }
    }
}
