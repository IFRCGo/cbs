using FluentValidation;

namespace Domain.StaffUser
{
    public class AssignedToNationalSocietiesValidator : AbstractValidator<IAmAssignedToNationalSocieties>
    {
        public AssignedToNationalSocietiesValidator()
        {
            RuleFor(ns => ns.AssignedNationalSocieties)
                .NotEmpty().WithMessage("Must be assigned to at least one National Society");
        }
    }
}