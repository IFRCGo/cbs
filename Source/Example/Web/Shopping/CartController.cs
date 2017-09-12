using System;
using Microsoft.AspNetCore.Mvc;

namespace Web.Shopping
{
    [Route("/Cart")]
    public class CartController
    {
        [Route("Item")]
        public void AddToCart(Guid productId, int quantity)
        {
            

        }
    }
}