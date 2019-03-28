using Microsoft.AspNetCore.Mvc;
using Read.KPI;
using Read.Models.KPI;
using System;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KPIController : ControllerBase
    {
        private readonly KPIRepository _kpiRepository;
        public KPIController(KPIRepository kpiRepository)
        {
            _kpiRepository = kpiRepository;
        }

        [HttpGet("{from}/{to}", Name = "GetKPIs")]
        public ActionResult<KPIs> GetKPIs(DateTimeOffset from, DateTimeOffset to)
        {
            return _kpiRepository.Get(from, to);
        }
    }
}