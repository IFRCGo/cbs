using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.Shopping;

namespace Web.Shopping
{
    [Route("api/Shopping/[controller]")]
    public class CartController : Controller
    {
        public CartController(ILogger<CartController> logger)
        {
        }

        [HttpGet]
        public Cart Get()
        {
            return new Cart();

        }


        [HttpPut("{product}")]
        public void Put(Guid product, [FromBody]int quantity)
        {
        }
    }
}