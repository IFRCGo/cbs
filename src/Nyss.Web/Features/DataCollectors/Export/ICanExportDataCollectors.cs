using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nyss.Web.Features.DataCollectors.Export
{
    public interface ICanExportDataCollectors
    {
        string Format { get; }
        string MIMEType { get; }
        string FileExtension { get; }
        void WriteDataCollectorsTo(IEnumerable<DataCollectorViewModel> dataCollectors, Stream stream);
    }
}
