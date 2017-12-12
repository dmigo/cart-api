using System;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// Implementation of a <see cref="T:Client:IShopClient"/>.
    /// </summary>
    public class ShopClient : IShopClient
    {
        /// <summary>
        /// Gets or sets the host of the remote shop.
        /// </summary>
        /// <value>The host.</value>
        public string Host { get; set; }
        /// <summary>
        /// Gets or sets the port of the remote shop.
        /// </summary>
        /// <value>The port.</value>
        public string Port { get; set; }

        /// <summary>
        /// Gets items in the cart.
        /// </summary>
        /// <returns>The cart.</returns>
        public IDictionary<Article, int> FetchCart()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Persists the items of the cart on the remote server.
        /// </summary>
        /// <param name="cart">Cart.</param>
        public void SubmitCart(IDictionary<Article, int> cart)
        {
            throw new NotImplementedException();
        }
    }
}
