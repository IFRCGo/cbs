using System;

namespace Domain.Shopping
{
    public class AddItemToCart
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}