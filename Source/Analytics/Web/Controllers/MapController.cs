using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly EpicurveService _epicurveService;
        public MapController(EpicurveService epicurveService)
        {
            _epicurveService = epicurveService;
        }

        [HttpGet("HealthRiskCoordinates/{from}/{to}", Name = "GetHealthRiskCoordinates")]
        public IEnumerable<OutbreakReport> GetHealthRiskCoordinates(DateTimeOffset from, DateTimeOffset to)
        {
            return _epicurveService.GetOutbreaks(from, to);
        }
    }
}