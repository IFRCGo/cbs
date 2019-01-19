using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Read.Reporting.CaseReportsForListing;

namespace Core.Utility
{
    interface IReportExporter
    {
        string GetMIMEType();
        string GetFileExtension();
        bool WriteReports(IEnumerable<CaseReportForListing> reports, string[] fields, Stream stream);
    }
}
