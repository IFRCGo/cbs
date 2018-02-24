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
using Domain.DataCollectors.CommandHandlers;
using Domain.DataCollectors.Commands;
using MongoDB.Driver;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/datacollectors")]
    public class DataCollectorsController : BaseController
    {
        private readonly IDataCollectors _dataCollectors;

        private readonly DataCollectorCommandHandler _dataCollectorCommandHandler;
        //readonly IAggregateRootRepositoryFor<Domain.DataCollectors.DataCollector> _dataCollector;

        public DataCollectorsController (
            DataCollectorCommandHandler dataCollectorCommand,
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
        public IActionResult Post([FromBody] AddDataCollector command)
        {
            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }
    }
}