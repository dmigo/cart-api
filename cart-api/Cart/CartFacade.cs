namespace Cart
{
    public class CartFacade : ICartFacade
    {
        Cart _cart =  new Cart
            {
                Items = new[]{
                    new CartItem{
                        ArticleId=1,
                        Quantity = 10
                    },
                    new CartItem{
                        ArticleId=32167,
                        Quantity = 2
                    },
                    new CartItem{
                        ArticleId=1337,
                        Quantity = 17
                    },
                }
            };

        
        public Cart GetCurrentCart()
        {
            return _cart;
        }
        public void UpdateCart(Cart cart)
        {
            _cart = cart;
        }
    }
}