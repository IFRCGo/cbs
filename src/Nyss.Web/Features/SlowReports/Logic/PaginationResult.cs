using System.Collections.Generic;

namespace Nyss.Web.Features.SlowReports
{
    public class PaginationResult<T> where T : class
    {
        public int TotalCount { get; set; }
        public int FilteredCount { get; set; }
        public List<T> Data { get; set; }

        public PaginationResult()
        {
            Data = new List<T>();
        }
    }
}