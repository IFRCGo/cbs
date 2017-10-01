using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Events;

namespace Events.External
{
    public class HealthRiskThresholdChanged : IEvent
    {
        /// <summary>
        /// The id of project wo which threshold is related to.
        /// </summary>
        public Guid ProjectId { get; set; }
        /// <summary>
        /// The id of disease wo which threshold is related to.
        /// </summary>
        public Guid HealthRiskId { get; set; }
        /// <summary>
        /// Number of cases per alert period that will trigger an alert.
        /// </summary>
        public int Threshold { get; set; }
        /// <summary>
        /// Period on which threshold is checked.
        /// </summary>
        public TimeSpan ThresholdPeriod { get; set; }
    }
}
