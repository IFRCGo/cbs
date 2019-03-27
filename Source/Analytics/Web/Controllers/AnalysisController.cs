using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.TestData;

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
