using System;
using System.Collections.Generic;
using System.Text;
using Read;

namespace Domain
{
    public interface IAlertFeedbackService
    {
        void SendFeedbackToDataCollecorsAndVerifiers(IEnumerable<CaseReport> latestReports);
    }
}
