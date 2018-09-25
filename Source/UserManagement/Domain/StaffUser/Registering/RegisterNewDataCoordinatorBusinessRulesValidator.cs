// using System;
// using System.Collections.Generic;
// using FluentValidation;
// using System.Linq;

// namespace Domain.StaffUser.Registering
// {
//     public class RegisterNewDataCoordinatorBusinessRulesValidator 
//                     : NewStaffRegistrationBusinessRulesValidator<RegisterNewDataCoordinator, Roles.DataCoordinator>
//     {
//         readonly CanAssignToNationalSociety _canAssignToNationalSociety;

//         public RegisterNewDataCoordinatorBusinessRulesValidator(
//             StaffUserIsRegistered isRegistered, 
//             CanAssignToNationalSociety canAssignToNationalSociety
//             ) 
//             : base(isRegistered)
//         {
//             _canAssignToNationalSociety = canAssignToNationalSociety;

//             RuleFor(_ => _.Role.AssignedNationalSocieties)
//                 .Must(BeAssignable).WithMessage("Cannot assign to the selected National Societies");
//         }

//         private bool BeAssignable(IEnumerable<Guid> nationalSocieties)
//         {
//             return nationalSocieties.All(ns => _canAssignToNationalSociety(ns));
//         }
//     }  
// }