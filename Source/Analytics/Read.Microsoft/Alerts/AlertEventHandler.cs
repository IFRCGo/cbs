using System;

namespace Read.Alerts
{
    public class AlertEventHandler : IAlertEventHandler
    {
        private readonly MongoDBHandler _dbHandler;

        public AlertEventHandler(MongoDBHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }

        public void Handle(Alert alert)
        {
            _dbHandler.Insert(alert);
        }
    }
}
