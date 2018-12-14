/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dolittle.Queries.Coordination;
using Dolittle.ReadModels;
using Read.DataCollectors;
using Web.Utility;

namespace Web.Controllers
{
    [Route("api/datacollectors")]
    public class DataCollectorsController : Controller
    {
        private readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;
        private readonly IQueryCoordinator _queryCoordinator;
        
        public DataCollectorsController (
            IReadModelRepositoryFor<DataCollector> dataCollectors,
            IQueryCoordinator queryCoordinator)
        {
            _dataCollectors = dataCollectors;
            _queryCoordinator = queryCoordinator;
        }

        private static readonly Dictionary<string, IDataCollectorExporter> exporters =
            new Dictionary<string, IDataCollectorExporter>
            {
                {"excel", new DataCollectorExcelExporter() },
                {"csv", new DataCollectorCsvExporter() }
            };


        [HttpGet("export")]
        public IActionResult Export(string format = "excel")
        {
            if (!exporters.ContainsKey(format)) return NotFound();

            var exporter = exporters[format];

            var dataCollectors = _dataCollectors.Query.AsParallel();

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