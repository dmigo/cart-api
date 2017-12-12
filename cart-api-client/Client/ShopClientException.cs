using System;
using System.Runtime.Serialization;

namespace Client
{
    /// <summary>
    /// Exception thrown by a shopping client.
    /// </summary>
    [Serializable]
    public class ShopClientException : Exception
    {
        public ShopClientException(Exception innerException) 
            : base("Client thrown an exception.", innerException)
        {
        }
    }
}