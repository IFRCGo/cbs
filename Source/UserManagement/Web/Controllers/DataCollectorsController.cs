using Domain;
using Events;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read;
using Read.DataCollectors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using doLittle.Domain;
using Domain.DataCollector.Registering;
using Domain.DataCollector.PhoneNumber;
using Domain.DataCollector.Update;
using Domain.DataCollector;
using MongoDB.Driver;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/datacollectors")]
    public class DataCollectorsController : BaseController
    {
        private readonly IDataCollectors _dataCollectors;

        private readonly IDataCollectorCommandHandler _dataCollectorCommandHandler;

        public DataCollectorsController (
            IDataCollectorCommandHandler dataCollectorCommand,
            IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
            _dataCollectorCommandHandler = dataCollectorCommand;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _dataCollectors.GetAllAsync();
            return Ok(items);
        }

        [HttpPost("add")]
        public IActionResult Post([FromBody] RegisterDataCollector command)
        {
            //TODO: Question: Set DataCollectorId here, in CommandHandler or make the request contain the DataCollectorId?
            command.DataCollectorId = Guid.NewGuid();
            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateDataCollector command)
        {
            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }
    }
}
