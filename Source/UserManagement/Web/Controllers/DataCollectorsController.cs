using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Dolittle.Queries;
using Dolittle.Queries.Coordination;
using MongoDB.Driver;
using Web.Utility;

namespace Web.Controllers
{
    [Route("api/datacollectors")]
    public class DataCollectorsController : Controller
    {
        private readonly IMongoDatabase _database;

        private readonly IQueryCoordinator _queryCoordinator;

        private readonly IDataCollectors _dataCollectors;
        public DataCollectorsController (
            IMongoDatabase database,
            IDataCollectors dataCollectors,
            IQueryCoordinator queryCoordinator)
        {
            _database = database;
            _dataCollectors = dataCollectors;
            _queryCoordinator = queryCoordinator;
        }

        private static Dictionary<string, IDataCollectorExporter> exporters =
            new Dictionary<string, IDataCollectorExporter>
            {
                {"excel", new DataCollectorExcelExporter() },
                {"csv", new DataCollectorCsvExporter() }
            };

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

        [HttpGet("export")]
        public async Task<IActionResult> Export(string format = "excel")
        {
            if (!exporters.ContainsKey(format)) return NotFound();

            var exporter = exporters[format];

            var dataCollectors = await _dataCollectors.GetAllAsync();

            var stream = new MemoryStream();
            var result = exporter.WriteDataCollectors(dataCollectors, stream);

            if (result)
            {
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, exporter.GetMIMEType(), "datacollectors-" + DateTimeOffset.UtcNow.ToString("yyyy-MMMM-dd") + exporter.GetFileExtension());
            }

            stream.Close();
            return StatusCode(500);

        }
    }
}
