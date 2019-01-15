using System.Collections.Generic;
using System.IO;
using Read.DataCollectors;

namespace Web.Utility
{
    public interface IDataCollectorExporter
    {
        string GetMIMEType();
        string GetFileExtension();
        bool WriteDataCollectors(IEnumerable<DataCollector> dataCollectors, Stream stream);
    }
}