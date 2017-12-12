using System;
using System.Runtime.Serialization;

namespace Client
{
    [Serializable]
    public class NegativeQuantityException : Exception
    {
        int id;
        int quantity;

        public NegativeQuantityException(int id, int quantity)
        {
            this.id = id;
            this.quantity = quantity;
        }
        public override string Message
        {
            get
            {
                return $"Quantity for the article with id {id} is {quantity}.";
            }
        }
    }
}