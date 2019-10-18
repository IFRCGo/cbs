using System.Threading.Tasks;
using Nyss.SmsGateway.Logic.Models;

namespace Nyss.SmsGateway.Logic
{
    public interface ISmsGatewayService
    {
        Task<ValidationResult> SaveReportAsync(Sms sms);
    }
}