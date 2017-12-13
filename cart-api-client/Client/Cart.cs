using System;
using System.Linq;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// Represents a shopping cart.
    /// </summary>
    public class Cart
    {
        IShopClient _client;

        IDictionary<Article, int> _items = new Dictionary<Article, int>();

        /// <summary>
        /// Gets the items int the cart.
        /// </summary>
        /// <value>The items.</value>
        public IDictionary<Article, int> Items => _items;

        public Cart(IShopClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Adds items to the cart.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="article">Article to be added.</param>
        /// <param name="quantity">Quantity of items to be added.</param>
        public void Add(Article article, int quantity)
        {
            if (article == null)
                throw new ArgumentNullException(nameof(article));

            var currentQuantity = _items.ContainsKey(article) ? _items[article] : 0;
            var newQuantity = currentQuantity + quantity;

            if (newQuantity < 0)
                throw new NegativeQuantityException(
                    article.Id,
                    quantity
                );

            _items[article] = newQuantity;
        }

        /// <summary>
        /// Removes all the items from the cart.
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Load the current state of the cart from the remote server.
        /// </summary>
        public void Load()
        {
            try
            {
                _items = _client.FetchCart().Result;
            }
            catch (Exception ex)
            {
                throw new ShopClientException(ex);
            }
        }

        /// <summary>
        /// Submit the current state of the cart from the remote server.
        /// </summary>
        public void Submit()
        {
            try
            {
                _client.SubmitCart(this.Items).Wait();
            }
            catch (Exception ex)
            {
                throw new ShopClientException(ex);
            }
        }
    }
}
