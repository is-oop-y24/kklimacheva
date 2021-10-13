using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        public void AddProductToCart(CartProduct product)
        {
            _customerCart.Add(product);
        }
    }
}