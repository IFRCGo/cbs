using System;
using System.Collections.Generic;
using System.Text;

namespace Read.CaseReports
{
    public class CaseReportTotals : IReadModel
    {
        public int Female { get; set; }
        public int Male { get; set; }
        public int Over5 { get; set; }
        public int Under5 { get; set; }
    }
}
