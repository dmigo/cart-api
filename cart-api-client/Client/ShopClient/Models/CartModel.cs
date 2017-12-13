using System.Collections.Generic;

namespace Client.ShopClient.Models
{
    class CartModel
    {
        public IEnumerable<CartItemModel> Items
        {
            get; set;
        }
    }
}
