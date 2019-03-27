using Read;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Web.Controllers
{
    // Todo: Move to proper place
    public class AnalysisService
    {
        private readonly MongoDBHandler _dbHandler;

        public AnalysisService(MongoDBHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }

        public AnalysisReport GetAggregation(
            DateTimeOffset @from, 
            DateTimeOffset to, 
            TimeAggregation timeAggregation,
            SelectedSeries[] selectedSeries)
        {
            var dbCaseEntry = _dbHandler.GetQueryable()
                .Where(x => x.Timestamp >= from && x.Timestamp < to)
                .ToList();

            var groups = dbCaseEntry.GroupBy(x => TimeWindowGrouping(x.Timestamp.Date, timeAggregation));

            var report = new AnalysisReport
            {
                From = @from,
                To = to,
                TimeAggregation = timeAggregation,
                Categories = groups.Select(x => x.Key).ToArray(),
                Series = GetSeries(groups, selectedSeries),
            };

            //List<string> categories = new List<string>();
            //List<int> series = new List<int>();
            //foreach (var group in groups)
            //{
            //    //report.Categories = groups.Select(x => x.Key.ToShortDateString()).ToArray();
            //    categories.Add(group.Key.ToShortDateString());
            //    series.Add(group.Sum(x => x.NumberOfMalesUnder5));
            //}

            //report.Categories = categories.ToArray();
            //report.Series = new[] {new Serie() {Label = "Males under 5", Data = series.ToArray()}};

            return report;
        }

        private string TimeWindowGrouping(DateTime date, TimeAggregation timeAggregation)
        {
            if (timeAggregation == TimeAggregation.Day)
            {
                return date.ToShortDateString();
            }

            return $"Week {GetIso8601WeekOfYear(date)}";
        }

        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private Serie[] GetSeries(IEnumerable<IGrouping<string, DbCaseEntry>> groups, SelectedSeries[] selectedSeries)
        {
            Dictionary<SelectedSeries, List<int>> serieDict = new Dictionary<SelectedSeries, List<int>>();

            foreach (var @group in groups)
            {

                foreach (var selectedSerie in selectedSeries)
                {

                    if (!serieDict.ContainsKey(selectedSerie))
                    {
                        serieDict.Add(selectedSerie, new List<int>());
                    }

                    serieDict[selectedSerie].Add(@group.Sum(Selector(selectedSerie)));
                }
            }

            List<Serie> series = new List<Serie>();
            foreach (var serie in serieDict)
            {
                series.Add(new Serie() { Label = serie.Key.ToString(), Data = serie.Value.ToArray() });
            }

            return series.ToArray();
        }

        private Func<DbCaseEntry, int> Selector(SelectedSeries selectedSeries)
        {
            switch (selectedSeries)
            {
                case SelectedSeries.Total:
                    return x =>
                        x.NumberOfFemalesAged5AndOlder +
                        x.NumberOfFemalesUnder5 +
                        x.NumberOfMalesAged5AndOlder +
                        x.NumberOfMalesUnder5;
                case SelectedSeries.Male:
                    return x =>
                        x.NumberOfMalesAged5AndOlder +
                        x.NumberOfMalesUnder5;
                case SelectedSeries.Female:
                    return x =>
                        x.NumberOfFemalesAged5AndOlder +
                        x.NumberOfFemalesUnder5;
                case SelectedSeries.AgeUnderFive:
                    return x =>
                        x.NumberOfMalesUnder5 +
                        x.NumberOfFemalesUnder5;
                case SelectedSeries.AgeFiveOrAbove:
                    return x =>
                        x.NumberOfFemalesAged5AndOlder +
                        x.NumberOfMalesAged5AndOlder;
                case SelectedSeries.FemaleUnderFive: return x => x.NumberOfFemalesUnder5;
                case SelectedSeries.FemaleFiveOrAbove: return x => x.NumberOfMalesAged5AndOlder;
                case SelectedSeries.MaleUnderFive: return x => x.NumberOfMalesUnder5;
                case SelectedSeries.MaleFiveOrAbove: return x => x.NumberOfMalesAged5AndOlder;
                default: return x => 0;
            }
            

        }
    }
}