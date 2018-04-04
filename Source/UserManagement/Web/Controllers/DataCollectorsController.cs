using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;
using System;
using doLittle.Read;
using Domain.DataCollector.Registering;
using Domain.DataCollector;
using MongoDB.Driver;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/datacollectors")]
    public class DataCollectorsController : BaseController
    {
        //private readonly IDataCollectors _dataCollectors;

        private readonly IMongoCollection<Read.DataCollectors.DataCollector> _collection;

        private readonly IDataCollectorCommandHandler _dataCollectorCommandHandler;

        private readonly IQueryCoordinator _queryCoordinator;

        private readonly IDataCollectors _dataCollectors;

        public DataCollectorsController (
            IMongoDatabase database,
            IDataCollectorCommandHandler dataCollectorCommand,
            IDataCollectors dataCollectors,
            IQueryCoordinator queryCoordinator)
        {
            _collection = database.GetCollection<Read.DataCollectors.DataCollector>("DataCollectors");
            _dataCollectorCommandHandler = dataCollectorCommand;
            _queryCoordinator = queryCoordinator;
            _dataCollectors = dataCollectors;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dataCollectors.GetAll());

        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDataCollector command)
        {
            command.DataCollectorId = Guid.NewGuid();
            command.IsNewRegistration = true;
            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] RegisterDataCollector command)
        {
            command.IsNewRegistration = false;
            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }
    }
}
