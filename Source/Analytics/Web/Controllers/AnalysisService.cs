using Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Read.CaseReports;
using Read.Models;
using Read.Model;

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
            var dbCaseEntry = _dbHandler.GetQueryable<CaseReport>()
                .Where(x => x.Timestamp >= from && x.Timestamp < to)
                .ToList();

            var groups = dbCaseEntry.OrderBy(x => x.Timestamp.Date).GroupBy(x => TimeWindowGrouping(x.Timestamp.Date, timeAggregation));

            var report = new AnalysisReport
            {
                From = @from,
                To = to,
                TimeAggregation = timeAggregation,
                Categories = groups.Select(x => x.Key).ToArray(),
                Series = GetSeries(groups, selectedSeries),
            };

            return report;
        }

        public IEnumerable<OutbreakReport> GetOutbreaks(DateTimeOffset @from, DateTimeOffset to)
        {
            var groups = _dbHandler.GetQueryable<CaseReport>()
                .Where(x => x.Timestamp >= from && x.Timestamp < to)
                .GroupBy(x => new
                {
                    x.Latitude,
                    x.Longitude,
                    x.HealthRisk
                })
                .ToList();

            List<OutbreakReport> list = new List<OutbreakReport>();
            foreach (var group in groups)
            {
                OutbreakReport report = new OutbreakReport();
                report.Center = new[] {group.Key.Latitude, group.Key.Longitude};
                report.Radius = group.Sum(x =>
                    x.NumberOfMalesUnder5 +
                    x.NumberOfFemalesUnder5 +
                    x.NumberOfFemalesAged5AndOlder +
                    x.NumberOfMalesAged5AndOlder);
                report.Popup = $"Something something {group.Key.HealthRisk}";
                report.Color = "red";

                list.Add(report);
            }



            //{
            //    new OutbreakReport()
            //    {
            //        Center = new[] {40.0, 40.0}, Color = "red", Radius = 45, Popup = "45 cases of Ebola"
            //    },
            //    new OutbreakReport()
            //    {
            //        Center = new[] {50.0, 30.0}, Color = "yellow", Radius = 23, Popup = "23 cases of Cholera"
            //    },
            //    new OutbreakReport()
            //    {
            //        Center = new[] {60.0, 20.0}, Color = "orange", Radius = 11, Popup = "11 cases of Measles"
            //    },
            //    new OutbreakReport()
            //    {
            //        Center = new[] {10.0, -30.0}, Color = "blue", Radius = 70, Popup = "70 cases of Acute watery diarrhea"
            //    }
            //};

            return list;
        }

        private string TimeWindowGrouping(DateTime date, TimeAggregation timeAggregation)
        {
            if (timeAggregation == TimeAggregation.Day)
            {
                return date.ToShortDateString();
            }
            
            return $"Week {date.GetWeekNumber()}";
        }

        private Serie[] GetSeries(IEnumerable<IGrouping<string, CaseReport>> groups, SelectedSeries[] selectedSeries)
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
                series.Add(new Serie() { Name = serie.Key.ToString(), Data = serie.Value.ToArray() });
            }

            return series.ToArray();
        }

        private Func<CaseReport, int> Selector(SelectedSeries selectedSeries)
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

    public class OutbreakReport
    {
        public double[] Center { get; set; }

        public string Color { get; set; }

        public int Radius { get; set; }

        public string Popup { get; set; }
    }
}