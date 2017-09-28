using System;

namespace Read
{
    public class Pricing : IPricing
    {
        public Price GetForProduct(Guid productId)
        {
            return new Price 
            { 
                Gross = 130,
                Net = 100
            };
        }
    }
}