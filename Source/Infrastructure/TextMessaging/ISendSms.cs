using System.Threading.Tasks;

namespace Infrastructure.TextMessaging
{
    public interface ISendSms
    {
        Task SendAsync(OutgoingTextMessage message);
        Task SendAsync(string receiverCountryCode, string number, string message);
    }
}
