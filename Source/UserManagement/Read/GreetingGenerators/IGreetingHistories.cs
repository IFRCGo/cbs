using System.Threading.Tasks;

namespace Read.GreetingGenerators
{
    public interface IGreetingHistories : IReadCollection<GreetingHistory>
    {
        Task<GreetingHistory> GetByPhoneNumberAsync(string phoneNumber);
        
        Task Remove(string phoneNumber);
        
    }
}