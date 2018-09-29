using Dolittle.Events.Processing;
using Events.VolunteerReporting.CaseReports;
using Dolittle.ReadModels;
using Infrastructure.Read.MongoDb;
using System.Globalization;
using System;

namespace Read.CaseReports
{
    public class CaseReportEventProcessors : ICanProcessEvents
    {
        private readonly IExtendedReadModelRepositoryFor<AlertsByWeek> _repository;

        public CaseReportEventProcessors(IExtendedReadModelRepositoryFor<AlertsByWeek> repository)
        {
            _repository = repository;
        }

        [EventProcessor("c69f65c5-94a7-4d9a-ae63-0f8add83d3da")]
        public void Process(CaseReportReceived @event)
        {
            var alertCount = @event.NumberOfFemalesAged5AndOlder + @event.NumberOfFemalesUnder5 + @event.NumberOfMalesAged5AndOlder + @event.NumberOfMalesUnder5;
            var weekNumber = GetWeekFromDate(@event.Timestamp.DateTime);

            var nationalSociety = new AlertsByWeek()
            {
                Year = (short)@event.Timestamp.DateTime.Year,
                Week = (short)weekNumber,
                AlertCount = alertCount
            };

            _repository.Insert(nationalSociety);
        }

        private short GetWeekFromDate(DateTime date)
        {
            var culture = CultureInfo.CurrentCulture;

            int result = culture.Calendar.GetWeekOfYear(
                date,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);

            return (short)result;
        }
    }
}
