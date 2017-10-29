using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SetProjectHealthRiskThreshold
    {
        public Guid ProjectId { get; set; }
        public Guid HealthRiskId { get; set; }
        public int Threshold { get; set; } 
    }
}
