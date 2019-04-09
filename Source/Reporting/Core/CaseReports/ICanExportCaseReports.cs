using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Read.Reporting.CaseReportsForListing;

namespace Core.CaseReports
{
    public interface ICanExportCaseReports
    {
        string Format { get; }
        string MIMEType { get; }
        string FileExtension { get; }
        void WriteReportsTo(IEnumerable<CaseReportForListing> reports, Stream stream);
    }
}
