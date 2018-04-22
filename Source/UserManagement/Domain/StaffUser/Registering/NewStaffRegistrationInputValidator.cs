using Dolittle.Commands.Validation;
using Dolittle.Reflection;
using FluentValidation;

namespace Domain.StaffUser.Registering
{
    public abstract class NewStaffRegistrationInputValidator<TCommand,TRole> : CommandInputValidatorFor<TCommand> 
        where TCommand : NewStaffRegistration<TRole>
        where TRole : Roles.StaffRole
    {

        // private Dictionary<Type,Type> _mappings = new Dictionary<Type, Type>()
        // {
        //     {typeof(IRequireAssignedNationalSocieties), typeof(RequireAssignedNationalSocietiesInputValidator)},
        //     {typeof(IRequireBirthYear), typeof(RequireBirthYearInputValidator)},
        //     {typeof(IRequireDutyStation), typeof(RequireDutyStationInputValidator)},
        //     {typeof(IRequireALocation), typeof(RequireLocationValidator)},
        //     {typeof(IRequireNationalSociety), typeof(RequireNationalSocietyInputValidator)},
        //     {typeof(IRequirePhoneNumbers), typeof(RequirePhoneNumbersInputValidator)},
        //     {typeof(IRequirePosition), typeof(RequirePositionInputValidator)},
        //     {typeof(IRequirePreferredLanguage), typeof(RequirePreferredLanguageInputValidator)},
        //     {typeof(IRequireSex), typeof(RequireSexInputValidator)},
        //     {typeof(ISupportBirthYear), typeof(SupportBirthYearInputValidator)},
        //     {typeof(ISupportPhoneNumbers), typeof(SupportPhoneNumbersInputValidator)},
        //     {typeof(ISupportSex), typeof(SupportSexInputValidator)},
        // };

        protected NewStaffRegistrationInputValidator()
        {
            RuleFor(_ => _.Role)
                .NotNull().WithMessage("Role is required")
                .SetValidator(new HaveUserInfoValidator());
            
            //TODO: This can be done much better!  Need to look into FluentValidation to
            //see how to set a validator without the fluent interface
            if(IsRole<IRequireAssignedNationalSocieties>())
            {
                RuleFor(_ => (_ as IRequireAssignedNationalSocieties))
                    .NotNull()
                    .SetValidator(new RequireAssignedNationalSocietiesInputValidator());
            }

            if(IsRole<IRequireBirthYear>())
            {
                RuleFor(_ => (_ as IRequireBirthYear))
                    .NotNull()
                    .SetValidator(new RequireBirthYearInputValidator());
            }

            if(IsRole<IRequireDutyStation>())
            {
                RuleFor(_ => (_ as IRequireDutyStation))
                    .NotNull()
                    .SetValidator(new RequireDutyStationInputValidator());
            }

            if(IsRole<IRequireLocation>())
            {
                RuleFor(_ => (_ as IRequireLocation))
                    .NotNull()
                    .SetValidator(new RequireLocationValidator());
            }

            if(IsRole<IRequireNationalSociety>())
            {
                RuleFor(_ => (_ as IRequireNationalSociety))
                    .NotNull()
                    .SetValidator(new RequireNationalSocietyInputValidator());
            }

            if(IsRole<IRequireNationalSociety>())
            {
                RuleFor(_ => (_ as IRequireNationalSociety))
                    .NotNull()
                    .SetValidator(new RequireNationalSocietyInputValidator());
            }

            if(IsRole<IRequirePhoneNumbers>())
            {
                RuleFor(_ => (_ as IRequirePhoneNumbers))
                    .NotNull()
                    .SetValidator(new RequirePhoneNumbersInputValidator());
            }

            if(IsRole<IRequirePosition>())
            {
                RuleFor(_ => (_ as IRequirePosition))
                    .NotNull()
                    .SetValidator(new RequirePositionInputValidator());
            } 

            if(IsRole<IRequirePreferredLanguage>())
            {
                RuleFor(_ => (_ as IRequirePreferredLanguage))
                    .NotNull()
                    .SetValidator(new RequirePreferredLanguageInputValidator());
            }    

            if(IsRole<IRequireSex>())
            {
                RuleFor(_ => (_ as IRequireSex))
                    .NotNull()
                    .SetValidator(new RequireSexInputValidator());
            }  

            if(IsRole<ISupportBirthYear>())
            {
                RuleFor(_ => (_ as ISupportBirthYear))
                    .NotNull()
                    .SetValidator(new SupportBirthYearInputValidator());
            }   

            if(IsRole<ISupportPhoneNumbers>())
            {
                RuleFor(_ => (_ as ISupportPhoneNumbers))
                    .NotNull()
                    .SetValidator(new SupportPhoneNumbersInputValidator());
            }  

            if(IsRole<ISupportSex>())
            {
                RuleFor(_ => (_ as ISupportSex))
                    .NotNull()
                    .SetValidator(new SupportSexInputValidator());
            }                     
        }

        bool IsRole<T>()
        {
            return typeof(T).HasInterface(typeof(TRole));
        }
    }
}