using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nyss.Web.Features.SmsGateway.Logic;

namespace Nyss.Web.Features.SmsGateway
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsGatewayController : ControllerBase
    {
        private readonly ISmsGatewayService _smsGatewayService;

        public SmsGatewayController(ISmsGatewayService smsGatewayService)
        {
            _smsGatewayService = smsGatewayService;
        }

        // GET: api/SmsGateway
        [HttpGet]
        public async Task<IActionResult> Get(SmsDto smsDto)
        {
            var sms = smsDto.ToLogicModel();
            var validationResult = await _smsGatewayService.SaveReportAsync(sms);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            return Ok();
        }

        // POST: api/SmsGateway
        [HttpPost]
        public async Task<IActionResult> Post(SmsDto smsDto)
        {
            var sms = smsDto.ToLogicModel();
            var validationResult = await _smsGatewayService.SaveReportAsync(sms);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            return Ok();
        }
    }
}
