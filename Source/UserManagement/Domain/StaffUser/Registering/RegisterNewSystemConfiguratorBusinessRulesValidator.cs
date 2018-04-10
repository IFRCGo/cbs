using System;
using System.Collections.Generic;
using FluentValidation;
using System.Linq;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewSystemConfiguratorBusinessRulesValidator 
                    : NewStaffRegistrationBusinessRulesValidator<RegisterNewSystemConfigurator, Domain.StaffUser.Roles.SystemConfigurator>
    {
        readonly CanAssignToNationalSociety _canAssignToNationalSociety;

        public RegisterNewSystemConfiguratorBusinessRulesValidator(
            StaffUserIsRegistered isRegistered,
            CanAssignToNationalSociety canAssignToNationalSociety,
            bool isNewRegistration) 
            : base(isRegistered, isNewRegistration)
        {
            _canAssignToNationalSociety = canAssignToNationalSociety;

            RuleFor(_ => _.Role.AssignedNationalSocieties)
                .Must(BeAssignable).WithMessage("Cannot assign to the selected National Societies");
        }

        private bool BeAssignable(IEnumerable<Guid> nationalSocieties)
        {
            return nationalSocieties.All(ns => _canAssignToNationalSociety(ns));
        }
    }
}