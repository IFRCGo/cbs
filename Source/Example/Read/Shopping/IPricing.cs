using System;

namespace Read.Shopping
{
    public interface IPricing
    {
         Price GetForProduct(Guid productId);
    }
}