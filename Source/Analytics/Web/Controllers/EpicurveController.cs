using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Read.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicurveController : ControllerBase
    {
        private readonly EpicurveService _epicurveService;

        public EpicurveController(EpicurveService epicurveService)
        {
            _epicurveService = epicurveService;
        }

        [HttpGet("{from}/{to}/{timeAggregation}", Name = "Get")]
        public Epicurve Get(DateTimeOffset from, DateTimeOffset to, TimeAggregation timeAggregation, [FromQuery]SelectedSeries[] selectedSeries)
        {
            return _epicurveService.GetAggregation(from, to, timeAggregation, selectedSeries);
        }
    }
}
