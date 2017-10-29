using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    // Prepared for vluent validation, but a bug seems to throw an exception (Issue #288)
    // Can probably be fixed once we have the infrastructure working

    public class SetProjectHealthRiskThreshold // : AbstractValidator<SetProjectHealthRiskThreshold>
    {
        //public SetProjectHealthRiskThreshold()
        //{
        //    RuleFor(v => v.Threshold).GreaterThan(0).WithMessage("The threshold can not be zero or negative");
        //    RuleFor(v => v).Must(HealthRiskBelongsToProject);
        //}

        //private bool HealthRiskBelongsToProject(SetProjectHealthRiskThreshold arg)
        //{
        //    // TODO: Use read model to verify the health risk is registered on the project
        //}

        public Guid ProjectId { get; set; }
        public Guid HealthRiskId { get; set; }
        public int Threshold { get; set; } 
    }
}
