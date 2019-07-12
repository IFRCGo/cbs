using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Alerts;
using Events.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.Reports.AvailableForRules
{
    class EventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<AvailableReport> _availableReports;

        public EventProcessor(
            IReadModelRepositoryFor<AvailableReport> availableReports
        )
        {
            _availableReports = availableReports;
        }

        [EventProcessor("9ea44541-94c7-494c-8f84-2d90004f8ce2")]
        public void Process(ReportRegistered @event)
        {
            var item = new AvailableReport
            {
                Id = @event.ReportId,                
                HealthRiskId = @event.HealthRiskId,
                HealthRiskNumber = @event.HealthRiskNumber,
                Latitude = @event.Latitude,
                Longitude = @event.Longitude,
                Timestamp = @event.Timestamp
            };
            _availableReports.Insert(item);
        }

        [EventProcessor("534c4f7c-a4dc-4bed-8202-a0bbab6d8fc7")]
        public void Process(AlertOpened @event)
        {
            foreach(var reportId in @event.Reports)
            {
                var report = _availableReports.GetById(reportId);
                if(report != null)
                    _availableReports.Delete(report);
            }            
        }

        [EventProcessor("f2e97576-e2a5-4104-bd11-2c1679f69db3")]
        public void Process(ReportAddedToAlert @event)
        {            
            var report = _availableReports.GetById(@event.ReportId);
            if(report != null)
                _availableReports.Delete(report);            
        }
    }
}
