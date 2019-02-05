using System;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.DataOwners;

namespace Read.DataOwners
{
    public class DataOwnerProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<DataOwner> _repositoryForDataOwner;

        public DataOwnerProcessor(
            IReadModelRepositoryFor<DataOwner> repositoryForDataOwner
        )
        {
            _repositoryForDataOwner = repositoryForDataOwner;
        }

        [EventProcessor("0164d17f-7a2c-cee8-6fca-7222b04ff3e2")]
        public void Process(DataOwnerRegistered @event)
        {
            var dataOwner = _repositoryForDataOwner.GetById(@event.Id);
            if (dataOwner == null)
                _repositoryForDataOwner.Insert(new DataOwner
                {
                    Id = @event.Id,
                    Email = @event.Email,
                    Name = @event.Name
                });
            else
                _repositoryForDataOwner.Update(new DataOwner

                {
                    Id = @event.Id,
                    Email = @event.Email,
                    Name = @event.Name
                });
        }
    }
}
