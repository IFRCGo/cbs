using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Nyss.Web.Features.HealthRisks
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthRisksController : ControllerBase
    {
        private readonly IHealthRisksService _healthRisksService;

        public HealthRisksController(
            IHealthRisksService healthRisksService)
        {
            _healthRisksService = healthRisksService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HealthRiskViewModel>), StatusCodes.Status200OK)]
        public IActionResult All()
        {
            return Ok(_healthRisksService.All());
        }

        [HttpGet("{code}")]
        [ProducesResponseType(typeof(HealthRiskViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByCode(string code)
        {
            var healthRisk = _healthRisksService.GetByCode(code);
            if (healthRisk == null) return NotFound();
            return Ok(healthRisk);
        }
    }
}