// using FluentValidation;

// namespace Domain.StaffUser
// {

//     public class RequireAssignedNationalSocietiesInputValidator : AbstractValidator<IRequireAssignedNationalSocieties>
//     {
//         public RequireAssignedNationalSocietiesInputValidator()
//         {
//             RuleFor(_ => _.AssignedNationalSocieties)
//                 .NotEmpty().WithMessage("Assigned National Societies are required");
//         }
//     }
// }