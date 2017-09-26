/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.Shopping;
using Infrastructure.Events;

namespace Web.Shopping
{
    [Route("api/Shopping/[controller]")]
    public class CartController : Controller
    {
        public CartController(
            IEventEmitter eventEmitter,
            ILogger<CartController> logger)
        {

        }

        [HttpGet]
        public Cart Get()
        {
            return new Cart();
        }
        
        
        [HttpPost, Route("Add")]
        public void Add(AddItemToCart command)
        {
        }

        [HttpPost, Route("Remove/{id}")]
        public void Remove(Guid id)
        {

        }
    }
}