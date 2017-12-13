using System;
using Client;

namespace Client.Example
{
    class Program
    {
        static void PrintCart(Cart cart)
        {
            foreach (var keyValue in cart.Items)
            {
                Console.WriteLine($"{keyValue.Key.Id}: {keyValue.Value}");
            }
        }

        static void Main(string[] args)
        {
            var host = "http://localhost";
            var port = 5000;

            var client = new Client.ShopClient.ShopClient { Host = host, Port = port };
            var cart = new Cart(client);

            cart.Load();
            Console.WriteLine("Loaded");
            PrintCart(cart);
            Console.WriteLine();

            var article = new Article { Id = 1111 };
            cart.Add(article, 10);
            PrintCart(cart);
            cart.Submit();
            Console.WriteLine("Submitted");
            Console.WriteLine();

            cart.Add(article, 111);
            PrintCart(cart);
            cart.Submit();
            Console.WriteLine("Submitted");
            Console.WriteLine();

            cart.Load();
            Console.WriteLine("Loaded");
            PrintCart(cart);
        }
    }
}
