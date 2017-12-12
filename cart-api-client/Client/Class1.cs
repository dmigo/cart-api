using System;
using System.Collections.Generic;

namespace Client
{
    //ToDo have some tests
    //ToDo add comments
    //ToDo split the file

    public class Article
    {
        public int Id
        {
            get;
            set;
        }
    }

    public class CartItem
    {
        public Article Article
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
    }

    public class ShopClient{
        public string Host { get; }
        public string Port { get; }

        public ShopClient(string host, string port)
        {
            Port = port;
            Host = host;
        }

        internal void FetchCart(){
            throw new NotImplementedException();
        }
        internal void SubmitCart(){
            throw new NotImplementedException();
        }
    }

    public class Cart
    {
        ShopClient _client;

        List<CartItem> _items = new List<CartItem>();
        public IEnumerable<CartItem> Items => _items;

        public Cart(ShopClient client)
        {
            _client = client;
        }

        public void Add(Article article, int quantity)
        {
            _items.Add(new CartItem { Article = article, Quantity = quantity });
        }

        public void Remove(Article article, int quantity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Article article)
        {
            throw new NotImplementedException();
        }

        public void Clear(){
            _items.Clear();
        }

        public void SetPosition(Article article, int position){
            //ToDo throw out of range 
            //ToDo throw article is not in cart
            throw new NotImplementedException();
        }
    }
}
