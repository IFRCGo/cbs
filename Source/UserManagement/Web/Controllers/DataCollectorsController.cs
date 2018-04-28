using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;
using System;
using Dolittle.Queries;
using Dolittle.Queries.Coordination;
using MongoDB.Driver;

namespace Web.Controllers
{
    [Route("api/datacollectors")]
    public class DataCollectorsController : Controller
    {
        private readonly IMongoDatabase _database;

        private readonly IQueryCoordinator _queryCoordinator;
        
        public DataCollectorsController (
            IMongoDatabase database,
            IDataCollectors dataCollectors,
            IQueryCoordinator queryCoordinator)
        {
            _database = database;
            _queryCoordinator = queryCoordinator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _queryCoordinator.Execute(new AllDataCollectors(_database), new PagingInfo());

            return Ok(result.Items);
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
    }
}
