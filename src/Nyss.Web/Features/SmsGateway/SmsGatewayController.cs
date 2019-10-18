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
            var smsProcessResult = await _smsGatewayService.SaveReportAsync(sms);

            if (!smsProcessResult.IsRequestValid)
                return BadRequest(smsProcessResult.RequestErrors);

            var response = new SmsResponseDto
            {
                PhoneNumber = smsProcessResult.PhoneNumber,
                FeedbackMessage = smsProcessResult.FeedbackMessage
            };

            return Ok(response);
        }

        // POST: api/SmsGateway
        [HttpPost]
        public async Task<IActionResult> Post(SmsDto smsDto)
        {
            var sms = smsDto.ToLogicModel();
            var smsProcessResult = await _smsGatewayService.SaveReportAsync(sms);

            if (!smsProcessResult.IsRequestValid)
                return BadRequest(smsProcessResult.RequestErrors);

            var response = new SmsResponseDto
            {
                PhoneNumber = smsProcessResult.PhoneNumber,
                FeedbackMessage = smsProcessResult.FeedbackMessage
            };

            return Ok(response);
        }
    }
}
