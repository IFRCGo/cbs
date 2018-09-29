// using FluentValidation;
// using System;

// namespace Domain.StaffUser
// {

//     public class SupportBirthYearInputValidator : AbstractValidator<ISupportBirthYear>
//     {
//         public SupportBirthYearInputValidator()
//         {
//             RuleFor(ei => ei.BirthYear)
//                 .InclusiveBetween(1900,DateTime.UtcNow.Year).WithMessage("Birth Year is invalid").When(_ => _ != null);
                
//         }
//     }
// }