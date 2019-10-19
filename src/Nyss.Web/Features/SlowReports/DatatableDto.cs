using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nyss.Web.Features.SlowReports
{
    public class DatatableDto<T> where T : class
    {
        [JsonProperty("draw")]
        public int Draw { get; set; }

        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }

        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }

        [JsonProperty("data")]
        public List<T> Data { get; set; }
    }
}
