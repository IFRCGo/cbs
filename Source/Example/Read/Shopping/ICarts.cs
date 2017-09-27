using System;

namespace Read.Shopping
{
    public interface ICarts
    {
        Cart GetById(Guid id);
        void Save(Cart cart);
        Guid GetCartIdForCurrentUser();
    }
}