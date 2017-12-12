using System;
using System.Collections.Generic;

namespace Client
{
    //ToDo add comments
    public class ShopClient : IShopClient
    {
        public string Host { get; set; }
        public string Port { get; set; }

        public IDictionary<Article, int> FetchCart()
        {
            throw new NotImplementedException();
        }

        public void SubmitCart(IDictionary<Article, int> cart)
        {
            throw new NotImplementedException();
        }
    }
}
