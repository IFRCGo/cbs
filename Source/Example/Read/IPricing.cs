using System;

namespace Read
{
    public interface IPricing
    {
         Price GetForProduct(Guid productId);
    }
}