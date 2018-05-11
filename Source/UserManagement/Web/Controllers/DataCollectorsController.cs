using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;
using System;
using Dolittle.Queries;
using Dolittle.Queries.Coordination;
using MongoDB.Driver;
using Read.DataCollectors.Queries;

namespace Web.Controllers
{
    [Route("api/datacollectors")]
    public class DataCollectorsController : Controller
    {
        private readonly IDataCollectors _dataCollectors;

        private readonly IQueryCoordinator _queryCoordinator;
        
        public DataCollectorsController (
            IDataCollectors dataCollectors,
            IQueryCoordinator queryCoordinator)
        {
            _dataCollectors = dataCollectors;
            _queryCoordinator = queryCoordinator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _queryCoordinator.Execute(new AllDataCollectors(_dataCollectors), new PagingInfo());

            return Ok(result.Items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _queryCoordinator.Execute(new DataCollectorById(_dataCollectors, id), new PagingInfo());

            if (result.Success)
            {
                return Ok(result.Items);
            }
            return new NotFoundResult();
        }
    }
}
