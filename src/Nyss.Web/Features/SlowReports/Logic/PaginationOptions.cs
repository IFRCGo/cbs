using System.Collections.Generic;

namespace Nyss.Web.Features.SlowReports.Logic
{
    public class PaginationOptions
    {
        public int Start { get; set; }
        public int Count { get; set; }
        public string Order { get; set; }
        public bool OrderAsc { get; set; }
        public Dictionary<string, string> SearchDictionary { get; set; }

        public PaginationOptions()
        {
            SearchDictionary = new Dictionary<string, string>();
            Start = 0;
            Count = -1;
            OrderAsc = true;
        }
    }
}
