/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Read
{
    public class Pricing : IPricing
    {
        public Price GetForProduct(Guid productId)
        {
            return new Price
            {
                Gross = 130,
                Net = 100
            };
        }
    }
}