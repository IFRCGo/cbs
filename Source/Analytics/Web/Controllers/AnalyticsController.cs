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
    public class AnalyticsController : ControllerBase
    {
        private readonly AnalyticsService _analyticsService;

        public AnalyticsController(AnalyticsService analyticsService)
        {
            _analyticsService = analyticsService ?? new AnalyticsService();
        }

        // GET: api/Analytics/5
        [HttpGet("{from}/{to}", Name = "Get")]
        public AnalyticsReport Get(DateTimeOffset from, DateTimeOffset to)
        {
            return _analyticsService.GetAggregation(from, to);
        }
    }
}
