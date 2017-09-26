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
        
        
        [HttpPut]
        public void Put(AddItemToCart command)
        {
        }
    }
}