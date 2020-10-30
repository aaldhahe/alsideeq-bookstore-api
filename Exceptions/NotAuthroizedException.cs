using System;

namespace alsideeq_bookstore_api.Exceptions
{
    public class NotAuthroizedException : Exception
    {
        public NotAuthroizedException(string message) : base(message)
        {
        }

        public NotAuthroizedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}