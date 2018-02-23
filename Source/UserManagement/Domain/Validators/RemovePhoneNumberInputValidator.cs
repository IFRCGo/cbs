/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using doLittle.FluentValidation.Commands;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class RemovePhoneNumberInputValidator : CommandInputValidator<RemovePhoneNumber>
    {
        public RemovePhoneNumberInputValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is not correct");

            // Role == null => StaffUserId must not be set and DataCollectorId must be set
            When(_ => _.Role == null, () =>
            {
                RuleFor(c => c.StaffUserId)
                    .Empty().WithMessage("Role and StaffUserId must not be set if either is not set");

                RuleFor(c => c.DataCollectorId)
                    .NotEmpty().WithMessage("If StaffUserId or Role is empty then DataCollectorId must be set");
            });

            // Role != null => StaffUserId must be set and DataCollectorId cannot be set
            When(_ => _.Role != null, () =>
            {
                RuleFor(c => c.StaffUserId)
                    .NotEmpty().WithMessage("If Role != null then StaffUserId must be set")
                    .NotEqual(Guid.Empty).WithMessage("If Role != null then StaffUserId must be set");

                RuleFor(c => c.DataCollectorId)
                    .Empty().WithMessage("If StaffUserId or Role is set then DataCollectorId cannot be set");
            });

            // StaffUserId != null => Role must be set and have a valid value and DataCollectorId must be Empty
            When(_ => _.StaffUserId != null, () =>
            {
                RuleFor(c => c.Role)
                    .IsInEnum().WithMessage("Role must be set and set to correct enum value");

                RuleFor(c => c.DataCollectorId)
                    .Empty().WithMessage("If StaffUserId or Role is set then DataCollectorId cannot be set");
            });

            // Role == null && (StaffUserId == null || StaffUserId == Guid.Empty())  => DataCollectorId cannot be null 
            When(c => c.Role == null && (c.StaffUserId == null || c.StaffUserId == Guid.Empty), () =>
            {
                RuleFor(c => c.DataCollectorId)
                    .NotEmpty().WithMessage("If Role and StaffUserId is not set then DataCollectorId must be set.");
            });
        }
    }
}
