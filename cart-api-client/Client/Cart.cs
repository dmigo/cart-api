using System;
using System.Linq;
using System.Collections.Generic;

namespace Client
{
    //ToDo add comments
    public class Cart
    {
        IShopClient _client;

        IDictionary<Article, int> _items = new Dictionary<Article, int>();

        public IDictionary<Article, int> Items => _items;

        public Cart(IShopClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

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

        public void Clear()
        {
            _items.Clear();
        }

        public void Load()
        {
            try
            {
                _items = _client.FetchCart();
            }
            catch (Exception ex)
            {
                throw new ShopClientException(ex);
            }
        }

        public void Submit()
        {
            try
            {
                _client.SubmitCart(this.Items);

            }
            catch (Exception ex)
            {
                throw new ShopClientException(ex);
            }
        }
    }
}
