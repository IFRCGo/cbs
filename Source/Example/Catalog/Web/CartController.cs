/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.AspNet;
using Read;
using Domain;
using Events;
using doLittle.Types;
using doLittle.Runtime.Events.Processing;
using System.Linq;

namespace Web
{
    [Route("api/shopping/cart")]
    public class CartController : BaseController
    {
        readonly ICarts _carts;
        readonly IPricing _pricing;
        readonly ILogger<CartController> _logger;
        readonly IServiceProvider _serviceProvider;

        public CartController(
            ICarts carts,
            IPricing pricing,
            ILogger<CartController> logger,
            IServiceProvider serviceProvider)
        {
            _carts = carts;
            _pricing = pricing;
            _logger = logger;
            _pricing = pricing;
            _serviceProvider = serviceProvider;
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

            var eventProcessors = _serviceProvider.GetService(typeof(IInstancesOf<IKnowAboutEventProcessors>)) as IInstancesOf<IKnowAboutEventProcessors>;
            var es = eventProcessors.ToArray();

            Apply(cartId, new ItemAddedToCart
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