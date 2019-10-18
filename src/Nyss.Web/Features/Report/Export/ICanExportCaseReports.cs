using System.Collections.Generic;
using System.IO;
using Nyss.Web.Features.Report;

namespace Nyss.Web.Features.Report.Export
{
    public interface ICanExportCaseReports
    {
        string Format { get; }
        string MIMEType { get; }
        string FileExtension { get; }
        void WriteReportsTo(IEnumerable<ReportViewModel> reports, Stream stream);
    }
}
