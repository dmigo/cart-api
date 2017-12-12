using System;
using System.Collections.Generic;

namespace Client
{
    //ToDo add comments
    public class ShopClient
    {
        public string Host { get; set; }
        public string Port { get; set; }

        internal IDictionary<Article, int> FetchCart()
        {
            throw new NotImplementedException();
        }

        internal void SubmitCart(IDictionary<Article, int> cart)
        {
            throw new NotImplementedException();
        }
    }
}
