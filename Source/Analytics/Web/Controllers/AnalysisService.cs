using Read;
using System;
using System.Collections.Generic;
using System.Linq;
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
}