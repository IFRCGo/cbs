// /*---------------------------------------------------------------------------------------------
//  *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
//  *  Licensed under the MIT License. See LICENSE in the project root for license information.
//  *--------------------------------------------------------------------------------------------*/

using System;

namespace Domain
{
    public class AddItemToCart
    {
        public Guid Product { get; set; }

        public int Quantity { get; set; }
    }
}