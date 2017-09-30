using System;

namespace Read
{
    public interface ICarts
    {
        Cart GetById(Guid id);
        void Save(Cart cart);
        Guid GetCartIdForCurrentUser();
    }
}