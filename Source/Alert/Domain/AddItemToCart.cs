using System;

namespace Domain
{
    public class AddItemToCart
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}