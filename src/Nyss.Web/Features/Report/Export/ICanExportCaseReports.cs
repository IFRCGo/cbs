using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Nyss.Web.Features.Report;

namespace Core.CaseReports
{
    public interface ICanExportCaseReports
    {
        string Format { get; }
        string MIMEType { get; }
        string FileExtension { get; }
        void WriteReportsTo(IEnumerable<ReportViewModel> reports, Stream stream);
    }
}
