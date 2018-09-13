// using FluentValidation;

// namespace Domain.StaffUser
// {

//     public class SupportSexInputValidator : AbstractValidator<ISupportSex>
//     {
//         public SupportSexInputValidator()
//         {
//             RuleFor(ei => ei.Sex)
//                 .IsInEnum().WithMessage("Sex is invalid").When(_ => _.Sex != null);
       
//         }
//     }
// }