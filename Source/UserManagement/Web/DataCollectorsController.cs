using Domain;
using Events;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read;
using Read.DataCollectors;
using System;
using System.Collections.Generic;
using doLittle.Domain;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web
{
    [Route("api/datacollectors/")]
    public class DataCollectorsController : BaseController
    {
        readonly IDataCollectors _dataCollectors;

        readonly IAggregateRootRepositoryFor<Domain.DataCollectors.DataCollector> _dataCollector;

        public DataCollectorsController(
            IAggregateRootRepositoryFor<Domain.DataCollectors.DataCollector> dataCollector,
            IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
            _dataCollector = dataCollector;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //TODO: This should limit nr of items somehow
            Console.WriteLine("in datacollectors");
            var items = _dataCollectors.GetAllDataCollectors();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddDataCollector command)
        {
            var dataCollector = _dataCollector.Get(command.Id);
            dataCollector.AddDataCollector(command);
            return Ok();
        }
    }
}
