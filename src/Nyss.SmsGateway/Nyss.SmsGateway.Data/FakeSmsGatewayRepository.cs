using System;
using System.Threading.Tasks;
using Nyss.Data.Models;

namespace Nyss.SmsGateway.Data
{
    public class FakeSmsGatewayRepository : ISmsGatewayRepository
    {
        public async Task<Report> InsertReportAsync(Report report)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<DataCollector> GetDataCollectorFromPhoneNumberAsync(string phoneNumber)
        {
            await Task.Delay(0);
            return new DataCollector
            {
                Id = -1,
                PhoneNumber = phoneNumber,
                DisplayName = "Henri Dunant",
                Name = "Henri Dunant"
            };
        }

        public async Task SaveChangesAsync()
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }
    }
}
