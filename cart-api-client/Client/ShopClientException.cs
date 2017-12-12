using System;
using System.Runtime.Serialization;

namespace Client
{
    [Serializable]
    public class ShopClientException : Exception
    {
        public ShopClientException(Exception innerException) 
            : base("Client thrown an exception.", innerException)
        {
        }
    }
}