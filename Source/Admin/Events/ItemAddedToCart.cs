// /*---------------------------------------------------------------------------------------------
//  *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
//  *  Licensed under the MIT License. See LICENSE in the project root for license information.
//  *--------------------------------------------------------------------------------------------*/

using System;
using Infrastructure.Events;

namespace Events
{
    public class ItemAddedToCart : IEvent
    {
        public Guid Cart { get; set; }

        public Guid Product { get; set; }

        public int Quantity { get; set; }

        public decimal GrossItemPrice { get; set; }

        public decimal NetItemPrice { get; set; }
    }
}