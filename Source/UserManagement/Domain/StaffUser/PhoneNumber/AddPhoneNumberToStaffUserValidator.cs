// using System;
// using Domain.StaffUser.PhoneNumber;
// using FluentValidation;

// namespace Domain.StaffUser.PhoneNUmber
// {
//     public class AddPhoneNumberToStaffUserValidator : AbstractValidator<AddPhoneNumberToStaffUser>
//     {
//         public AddPhoneNumberToStaffUserValidator()
//         {
//             CascadeMode = CascadeMode.StopOnFirstFailure;

//             RuleFor(_ => _.StaffUserId)
//                 .NotEmpty().WithMessage("StaffUserId cannot be empty")
//                 .NotEqual(Guid.Empty).WithMessage("StaffUserId cannot be Guid.Empty");

//             RuleFor(_ => _.PhoneNumber)
//                 .NotEmpty().WithMessage("PhoneNumber cannot be empty");
//         }
//     }
// }