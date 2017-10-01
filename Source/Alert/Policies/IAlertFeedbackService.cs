using System.Collections.Generic;
using Read;

namespace Policies
{
    public interface IAlertFeedbackService
    {
        void SendFeedbackToDataCollecorsAndVerifiers(IEnumerable<CaseReport> latestReports);
    }
}
