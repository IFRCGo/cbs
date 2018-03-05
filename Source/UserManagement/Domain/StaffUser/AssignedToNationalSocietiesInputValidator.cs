using FluentValidation;

namespace Domain.StaffUser
{
    public class AssignedToNationalSocietiesInputValidator : AbstractValidator<IAmAssignedToNationalSocieties>
    {
        public AssignedToNationalSocietiesInputValidator()
        {
            RuleFor(ns => ns.AssignedNationalSocieties)
                .NotEmpty().WithMessage("Must be assigned to at least one National Society");
        }
    }
}