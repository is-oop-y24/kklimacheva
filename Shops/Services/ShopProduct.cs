using Shops.Tools;

namespace Shops.Services
{
    public class ShopProduct
    {
        private int _amount;
        private float _price;
        public ShopProduct(Product product, int amount, float price)
        {
            ProductInstance = product;
            _amount = amount;
            _price = price;
        }

        public Product ProductInstance { get; }

        public int Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                {
                    throw new AmountException("Amount can't be negative.");
                }

                _amount = value;
            }
        }

        public float Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new PriceException("Price can't be negative.");
                }

                _price = value;
            }
        }
    }
}