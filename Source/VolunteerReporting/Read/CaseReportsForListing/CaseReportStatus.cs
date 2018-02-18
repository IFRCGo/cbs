using System;
using System.Collections.Generic;
using System.Text;

namespace Read.CaseReportsForListing
{
    public enum CaseReportStatus
    {
        Success,
        TextMessageParsingError,
        UnknownDataCollector,
        TextMessageParsingErrorAndUnknownDataCollector
    }
}
