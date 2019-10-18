using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyss.Web.Features.AlertHistory
{
    public interface IAlertHistoryService
    {
        IEnumerable<AlertHistoryViewModel> Get();
    }

    public class AlertHistoryService : IAlertHistoryService
    {
        public IEnumerable<AlertHistoryViewModel> Get()
        {
            var list = new List<AlertHistoryViewModel>();
            list.Add(new AlertHistoryViewModel { Village = "Brussel" });
            return list;
        }
    }
}
