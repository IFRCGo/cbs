using System;
using System.Collections.Generic;
using doLittle.FluentValidation.Commands;
using FluentValidation;
using System.Linq;

namespace Domain.StaffUser.Registering
{
    public class RegisterNewDataCoordinatorBusinessRulesValidator : NewRegistrationBusinessRulesValidator<RegisterNewDataCoordinator>
    {
        readonly CanAssignToNationalSociety _canAssignToNationalSociety;

        public RegisterNewDataCoordinatorBusinessRulesValidator(StaffUserIsRegistered isRegistered, 
                                                                    CanAssignToNationalSociety canAssignToNationalSociety) 
            : base(isRegistered)
        {
            _canAssignToNationalSociety = canAssignToNationalSociety;

            RuleFor(_ => _.AssignedNationalSocieties)
                .Must(BeAssignable).WithMessage("Cannot assign to the selected National Societies");
                
        }

        private bool BeAssignable(IEnumerable<Guid> nationalSocieties)
        {
            return nationalSocieties.All(ns => _canAssignToNationalSociety(ns));
        }
    }    
}