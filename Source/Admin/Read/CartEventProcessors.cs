// /*---------------------------------------------------------------------------------------------
//  *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
//  *  Licensed under the MIT License. See LICENSE in the project root for license information.
//  *--------------------------------------------------------------------------------------------*/

using Events;
using Infrastructure.Events;

namespace Read
{
    public class CartEventProcessors : IEventProcessor
    {
        readonly ICarts _carts;

        public CartEventProcessors(ICarts carts)
        {
            _carts = carts;
        }

        public void Process(ItemAddedToCart @event)
        {
            var cart = _carts.GetById(@event.Cart);
            cart.Add(@event.Product, @event.Quantity, new Price
            {
                Net = @event.NetItemPrice,
                Gross = @event.GrossItemPrice
            });
            _carts.Save(cart);
        }
    }
}