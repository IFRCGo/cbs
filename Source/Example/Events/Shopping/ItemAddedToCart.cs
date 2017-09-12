namespace Events.Shopping
{
    public class ItemAddedToCart
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal NetPrice { get; set; }
    }
}