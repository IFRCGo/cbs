using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;
using System;
using System.Linq;
using doLittle.Read;
using Domain.DataCollector.Registering;
using Domain.DataCollector;
using MongoDB.Driver;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/datacollectors")]
    public class DataCollectorsController : BaseController
    {
     
        private readonly IMongoDatabase _database;

        private readonly IDataCollectorCommandHandler _dataCollectorCommandHandler;

        private readonly IQueryCoordinator _queryCoordinator;
        
        public DataCollectorsController (
            IMongoDatabase database,
            IDataCollectorCommandHandler dataCollectorCommand,
            IDataCollectors dataCollectors,
            IQueryCoordinator queryCoordinator)
        {
            _database = database;
            _dataCollectorCommandHandler = dataCollectorCommand;
            _queryCoordinator = queryCoordinator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _queryCoordinator.Execute(new AllDataCollectors(_database), new PagingInfo());

            if (result.Success)
            {
                return Ok(result.Items);
            }

            return new NotFoundResult();  
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _queryCoordinator.Execute(new DataCollectorById(_database, id), new PagingInfo());

            if (result.Success)
            {
                return Ok(result.Items);
            }
            return new NotFoundResult();
        }

        [HttpPost]
        public IActionResult Register([FromBody] Read.DataCollectors.DataCollector dataCollector)
        {
            var command = new RegisterDataCollector
            {
                DataCollectorId = Guid.NewGuid(),
                IsNewRegistration = true,
                RegisteredAt = DateTimeOffset.UtcNow,
                PhoneNumbers = dataCollector.PhoneNumbers.Select(pn => pn.Value),
                DisplayName = dataCollector.DisplayName,
                FullName = dataCollector.FullName,
                GpsLocation = dataCollector.Location,
                NationalSociety = dataCollector.NationalSociety,
                PreferredLanguage = dataCollector.PreferredLanguage,
                Sex = dataCollector.Sex,
                YearOfBirth = dataCollector.YearOfBirth

            };
            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Read.DataCollectors.DataCollector dataCollector)
        {
            // TODO: Woksin (10/04/18): Hmm, I'm thinking here, maybe send the original DataCollector with command
            // to compare fields, and from there the AggregateRoot can decide which fields to update? @einari 
            var command = new RegisterDataCollector
            {
                DataCollectorId = dataCollector.DataCollectorId,
                IsNewRegistration = false,
                RegisteredAt = dataCollector.RegisteredAt,
                PhoneNumbers = dataCollector.PhoneNumbers.Select(pn => pn.Value),
                DisplayName = dataCollector.DisplayName,
                FullName = dataCollector.FullName,
                GpsLocation = dataCollector.Location,
                NationalSociety = dataCollector.NationalSociety,
                PreferredLanguage = dataCollector.PreferredLanguage,
                Sex = dataCollector.Sex,
                YearOfBirth = dataCollector.YearOfBirth
            };

            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }
    }
}
