using System;
using Microsoft.AspNetCore.Mvc;
using Read.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly AnalysisService _analysisService;

        public AnalysisController(AnalysisService analysisService)
        {
            _analysisService = analysisService;
        }

        [HttpGet("{from}/{to}/{timeAggregation}", Name = "Get")]
        public AnalysisReport Get(DateTimeOffset from, DateTimeOffset to, TimeAggregation timeAggregation, [FromQuery]SelectedSeries[] selectedSeries)
        {
            return _analysisService.GetAggregation(from, to, timeAggregation, selectedSeries);
        }
    }
}
