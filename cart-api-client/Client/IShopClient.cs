using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// Defines methods for communicating to a remote server.
    /// </summary>
    public interface IShopClient
    {
        IDictionary<Article, int> FetchCart();
        void SubmitCart(IDictionary<Article, int> cart);
    }
}
