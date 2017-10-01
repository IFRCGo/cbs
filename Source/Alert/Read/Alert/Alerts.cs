using MongoDB.Driver;

namespace Read.Alert
{
    public class Alerts : Repository<Alert>, IAlerts
    {
        public Alerts(IMongoDatabase database) : base(database, "Alert")
        {
        }
    }
}