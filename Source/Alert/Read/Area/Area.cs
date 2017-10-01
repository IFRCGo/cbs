using System;
using System.Collections.Generic;
using System.Text;

namespace Read
{
    public class Area : Entity
    {
        /// <summary>
        /// The id of project wo which threshold is related to.
        /// </summary>
        public Guid ProjectId { get; set; }

        public Guid[] DataCollectorIds { get; set; }
    }
}
