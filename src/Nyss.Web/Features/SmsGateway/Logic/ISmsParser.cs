using Nyss.Web.Features.SmsGateway.Logic.Models;

namespace Nyss.Web.Features.SmsGateway.Logic
{
    public interface ISmsParser
    {
        Case ParseSmsToCase(string smsText);
    }
}