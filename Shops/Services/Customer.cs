using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shops.Tools;

namespace Shops.Services
{
    public class Customer
    {
        private readonly List<CartProduct> _customerCart = new List<CartProduct>();
        public Customer(string name, float balance)
        {
            Balance = balance;
            Name = name;
        }

        public string Name { get; }
        public float Balance { get; set; }

        public ReadOnlyCollection<CartProduct> GetCustomerCart()
        {
            return _customerCart.AsReadOnly();
        }

        public void BuyProduct(ShopProduct product, int amount)
        {
            if (product.Price * amount > Balance)
            {
                throw new BalanceException("Not enough money to buy this product.");
            }

            if (product.Amount < amount)
            {
                throw new AmountException("Not enough amount of a product.");
            }

            Balance -= product.Price * amount;
            _customerCart.Add(new CartProduct(product.ProductInstance, amount));
        }
    }
}