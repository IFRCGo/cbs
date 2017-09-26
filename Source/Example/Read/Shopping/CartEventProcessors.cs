using Events.Shopping;

namespace Read.Shopping
{
    public class CartEventProcessors : Infrastructure.Events.IEventProcessor
    {

        public void Process(ItemAddedToCart @event)
        {

            // Save to Db / Keep in Session - something something
            
        }
        
    }
}