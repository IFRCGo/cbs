using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    public class ProjectEventMessage
    {
        /// <summary>
        /// The id of project wo which threshold is related to.
        /// </summary>
        public Guid ProjectId { get; set; }

        public Guid Id { get; set; }

        public Guid DiseaseId { get; set; }

        public string EventTriggerType { get; set; }

        public string MessageTemplateName { get; set; }
    }
}
