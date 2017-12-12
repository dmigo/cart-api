using System.Collections.Generic;

namespace Client
{
    public interface IShopClient
    {

        IDictionary<Article, int> FetchCart();
        void SubmitCart(IDictionary<Article, int> cart);
    }
}
