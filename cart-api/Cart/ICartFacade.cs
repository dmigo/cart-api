namespace Cart
{
    public interface ICartFacade
    {
        Cart GetCurrentCart();
        void UpdateCart(Cart cart);
         
    }
}