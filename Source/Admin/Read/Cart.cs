/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Read
{
    public class Cart
    {
        IList<CartLine> _lines;

        public Cart()
        {
            _lines = new List<CartLine>();
        }

        public Guid Id { get; set; }

        public IEnumerable<CartLine> Lines
        {
            get { return _lines; }
            set { _lines = new List<CartLine>(value); }
        }

        public void Add(Guid product, int quantity, Price price)
        {
            var existing = Lines.Where(p => p.Product == product).SingleOrDefault();
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                _lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity,
                    Price = price
                });
            }
        }
    }
}