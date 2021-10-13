using System;

namespace Shops.Tools
{
    public class PriceException : ShopsException
    {
        public PriceException()
        {
        }

        public PriceException(string message)
            : base(message)
        {
        }

        public PriceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}