// using System;
// using Dolittle.Commands.Validation;
// using Domain.StaffUser.Roles;
// using FluentValidation;

// namespace Domain.StaffUser.Changing
// {
//     public class AddAssignedNationalSocietyValidator : CommandInputValidatorFor<AddAssignedNationalSociety>
//     {
//         public AddAssignedNationalSocietyValidator()
//         {
//             RuleFor(bi => bi.StaffUserId)
//                 .NotEmpty().WithMessage("An Id for the Staff User is required.");

//             RuleFor(_ => _.Role)
//                 .Must(role => role.HasAssignedNationalSocieties()).WithMessage("This kind of Staffuser does not have assigned national societies");

//             RuleFor(_ => _.NationalSociety)
//                 .NotEmpty().WithMessage("The National society you want to add cannot be empty")
//                 .NotEqual(Guid.Empty).WithMessage("The National society you want to add cannot be empty");
//         }
//     }
// }