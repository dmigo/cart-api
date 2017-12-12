using System;
using System.Linq;
using System.Collections.Generic;

namespace Client
{
    //ToDo have some tests
    //ToDo add comments
    public class Cart
    {
        ShopClient _client;

        IDictionary<Article, int> _items = new Dictionary<Article, int>();

        public IDictionary<Article, int> Items => _items;

        public Cart(ShopClient client)
        {
            _client = client;
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

        public void Remove(Article article)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _items.Clear();
        }

        public void SetPosition(Article article, int position)
        {
            //ToDo throw out of range 
            //ToDo throw article is not in cart
            throw new NotImplementedException();
        }

        public void Load(){
            _items = _client.FetchCart();
        }

        public void Submit(){
            _client.SubmitCart(this.Items);
        }
    }
}
