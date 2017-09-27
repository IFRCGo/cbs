using System;

namespace Read.Shopping
{
    public class Carts : ICarts
    {
        public Cart GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid GetCartIdForCurrentUser()
        {
            return Guid.NewGuid();
        }

        public void Save(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}