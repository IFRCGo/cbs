using System;

namespace Read
{
    public class CartLine
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
        public Price Price { get; set; }
    }
}