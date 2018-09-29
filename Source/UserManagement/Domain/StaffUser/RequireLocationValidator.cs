// using FluentValidation;

// namespace Domain.StaffUser
// {
//     public class RequireLocationValidator : AbstractValidator<IRequireLocation>
//     {
//         public RequireLocationValidator()
//         {
//             RuleFor(l => l.Location)
//                 .Cascade(CascadeMode.StopOnFirstFailure)
//                 .NotNull().WithMessage("Location must be provided")
//                 .Must(l => l.IsValid()).WithMessage("Location is invalid.  Latitude must be in the range -90 to 90 and longitude in the range -180 to 180");
//         }
//     }
// }