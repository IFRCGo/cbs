/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain.Shopping;
using Events.Shopping;
using Infrastructure.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.Shopping;
using System;

namespace WebApi.Shopping
{
    [Route("api/shopping/cart")]
    public class CartController : Controller
    {
        public static readonly EventOrigin Origin = EventOrigin.FromStrings("Shopping", "Cart");

        readonly IEventEmitter _eventEmitter;
        readonly ILogger<CartController> _logger;

        public CartController(
            IEventEmitter eventEmitter,
            ILogger<CartController> logger)
        {
            _eventEmitter = eventEmitter;
            _logger = logger;
        }


        [HttpGet]
        public Cart Get()
        {
            return new Cart();
        }


        [HttpPost("items")]
        public void Add([FromBody]AddItemToCart command)
        {
            // Get the cart ID for current user 

            // Get current price for item

            _eventEmitter.Emit(Origin, new ItemAddedToCart
            {
                Cart = Guid.NewGuid(),
                Product = command.Product
            });
        }

        [HttpDelete("items/{id}")]
        public void Remove(Guid id)
        {

        }
    }
}