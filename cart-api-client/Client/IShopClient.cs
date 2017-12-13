using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Defines methods for communicating to a remote server.
    /// </summary>
    public interface IShopClient
    {
        Task<IDictionary<Article, int>> FetchCart();
        Task SubmitCart(IDictionary<Article, int> cart);
    }
}
