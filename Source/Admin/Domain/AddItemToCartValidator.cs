// /*---------------------------------------------------------------------------------------------
//  *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
//  *  Licensed under the MIT License. See LICENSE in the project root for license information.
//  *--------------------------------------------------------------------------------------------*/

using System;
using FluentValidation;

namespace Domain
{
    public class AddItemToCartValidator : AbstractValidator<AddItemToCart>
    {
        public AddItemToCartValidator()
        {
            RuleFor(_ => _.Product).Must(BeAValidProduct);

            RuleFor(_ => _.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity is not correct - it needs to be 1 or greater");
        }

        private bool BeAValidProduct(Guid arg)
        {
            return false;
        }
    }
}