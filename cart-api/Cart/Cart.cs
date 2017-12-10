using System.Collections.Generic;

namespace Cart
{
    public class Cart
    {
        public IEnumerable<CartItem> Items { get; set; }
    }
}