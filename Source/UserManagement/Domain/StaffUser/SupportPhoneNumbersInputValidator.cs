// using FluentValidation;
// using System.Collections.Generic;
// using System.Linq;

// namespace Domain.StaffUser
// {
//     public class SupportPhoneNumbersInputValidator : AbstractValidator<ISupportPhoneNumbers>
//     {
//         public SupportPhoneNumbersInputValidator()
//         {
//             RuleFor(_ => _.PhoneNumbers)
//                 .Must((IEnumerable<string> c) => c.Any(s => !string.IsNullOrWhiteSpace(s)))
//                 .When(_ => _.PhoneNumbers != null && _.PhoneNumbers.Any())
//                 .WithMessage("A Phone Number is required");
//         }
//     }
// }