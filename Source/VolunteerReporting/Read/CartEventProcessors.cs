using Events;

namespace Read
{
    public class CartEventProcessors : Infrastructure.Events.IEventProcessor
    {
        readonly ICarts _carts;

        public CartEventProcessors(ICarts carts)
        {
            _carts = carts;
        }

        public void Process(ItemAddedToCart @event)
        {
            var cart = _carts.GetById(@event.Cart);
            cart.Add(@event.Product, @event.Quantity, new Price 
            {
                Net = @event.NetItemPrice,
                Gross = @event.GrossItemPrice
            });
            _carts.Save(cart);
        }
    }
}