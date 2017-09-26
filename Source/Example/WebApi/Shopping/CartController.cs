/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.Events;
using Domain.Shopping;
using Read.Shopping;
using Events.Shopping;

namespace Web.Shopping
{
    [Route("api/Shopping/[controller]")]
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

        
        [HttpPost, Route("Add")]
        public void Add([FromBody]AddItemToCart command)
        {
            // Get the cart ID for current user 

            // Get current price for item

            _eventEmitter.Emit(Origin, new ItemAddedToCart {
                Cart = Guid.NewGuid(),
                Product = command.Product
            });
        }

        [HttpPost, Route("Remove/{id}")]
        public void Remove(Guid id)
        {

        }
    }
}