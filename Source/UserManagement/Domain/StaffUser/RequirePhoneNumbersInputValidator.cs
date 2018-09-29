// using FluentValidation;
// using System.Collections.Generic;
// using System.Linq;

// namespace Domain.StaffUser
// {
//     public class RequirePhoneNumbersInputValidator : AbstractValidator<IRequirePhoneNumbers>
//     {
//         public RequirePhoneNumbersInputValidator()
//         {
//             RuleFor(_ => _.PhoneNumbers)
//                 .Cascade(CascadeMode.StopOnFirstFailure)
//                 .NotNull().WithMessage("At least one phone number is required")
//                 .Must((IEnumerable<string> c) => c.Any(s => !string.IsNullOrWhiteSpace(s)))
//                 .WithMessage("Contains invalid phone numbers");
//         }
//     }          
// }