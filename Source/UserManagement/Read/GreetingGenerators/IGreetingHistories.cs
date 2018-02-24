using System.Threading.Tasks;

namespace Read.GreetingGenerators
{
    public interface IGreetingHistories : IReadCollection<GreetingHistory>
    {
        GreetingHistory GetByPhoneNumber(string phoneNumber);
        Task<GreetingHistory> GetByPhoneNumberAsync(string phoneNumber);

        void Remove(string phoneNumber);
        Task RemoveAsync(string phoneNumber);
        
    }
}