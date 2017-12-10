using System.Collections.Generic;

namespace Api.Models
{
    public class Cart
    {
        public Cart(List<CartItem> Items = default(List<CartItem>))
        {
            this.Items = Items;
        }

        public IEnumerable<CartItem> Items { get; set; }
    }
}