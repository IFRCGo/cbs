/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.Application;
using Infrastructure.Events;
using Read;
using Domain;
using Events;

namespace Web
{
    [Route("api/shopping/cart")]
    public class CartController : Controller
    {
        public static readonly Feature Feature = "Cart";

        readonly ICarts _carts;
        readonly IEventEmitter _eventEmitter;
        readonly IPricing _pricing;
        readonly ILogger<CartController> _logger;

        public CartController(
            ICarts carts,
            IPricing pricing,
            IEventEmitter eventEmitter,
            ILogger<CartController> logger)
        {
            _carts = carts;
            _eventEmitter = eventEmitter;
            _pricing = pricing;
            _logger = logger;
            _pricing = pricing;
        }


        [HttpGet]
        public Cart Get()
        {
            return new Cart();
        }


        [HttpPost("items")]
        public void Add([FromBody]AddItemToCart command)
        {
            var cartId = _carts.GetCartIdForCurrentUser();
            var price = _pricing.GetForProduct(command.Product);

            _eventEmitter.Emit(Feature, new ItemAddedToCart
            {
                Cart = cartId,
                Product = command.Product,
                Quantity = command.Quantity,
                NetItemPrice = price.Net,
                GrossItemPrice = price.Gross
            });
        }

        [HttpDelete("items/{id}")]
        public void Remove(Guid id)
        {

        }
    }
}