using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using Client.ShopClient.Models;


namespace Client.ShopClient
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
        public int Port { get; set; }

        /// <summary>
        /// Gets items in the cart.
        /// </summary>
        /// <returns>The cart.</returns>
        public async Task<IDictionary<Article, int>> FetchCart()
        {
            using (var client = CreateHttpClient())
            {
                var response = await client.GetAsync("/api/cart");
                response.EnsureSuccessStatusCode();

                var cartModel = await response.Content.ReadAsAsync<CartModel>();
                return cartModel.Items.ToDictionary(
                    item => new Article { Id = item.Article.Id },
                    item => item.Quantity
                );
            }
        }

        /// <summary>
        /// Persists the items of the cart on the remote server
        /// </summary>
        /// <param name="cart">Cart.</param>
        public async Task SubmitCart(IDictionary<Article, int> cart)
        {
            using (var client = CreateHttpClient())
            {
                var cartModel = new CartModel
                {
                    Items = cart.Select(
                        keyValue => new CartItemModel
                        {
                            Article = new ArticleModel { Id = keyValue.Key.Id },
                            Quantity = keyValue.Value
                        })
                };
                var response = await client.PutAsJsonAsync(
                        "/api/cart",
                        cartModel);
                response.EnsureSuccessStatusCode();
            }
        }

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{Host}:{Port}/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
