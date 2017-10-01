/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Read
{
    public class CartLine
    {
        public Guid Product { get; set; }

        public int Quantity { get; set; }

        public Price Price { get; set; }
    }
}