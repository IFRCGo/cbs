using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    public class ProjectMessageTemplateCreated
    {
        /// <summary>
        /// The id of project wo which threshold is related to.
        /// </summary>
        public Guid ProjectId { get; set; }

        public Guid Id { get; set; }

        public Guid DiseaseId { get; set; }

        public string TemplateName { get; set; }

        public string LanguageName { get; set; }

        public string Text { get; set; }
    }
}
