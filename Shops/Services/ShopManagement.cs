using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManagement : IShopManagement
    {
        private readonly List<Shop> _database = new List<Shop>();

        public Shop AddShop(string name, string address)
        {
            var newShop = new Shop(name, address);
            _database.Add(newShop);
            return newShop;
        }

        public void CustomerMakePurchase(Customer customer, Shop shop, Product product, int amount)
        {
            if (!IsShopInDatabase(shop))
            {
                throw new ShopsException("No such shop in database.");
            }

            if (shop.IsInCatalog(product))
            {
                throw new ProductExistenceException("No such product in catalog.");
            }

            customer.BuyProduct(shop.FindProduct(product), amount);
            shop.FindProduct(product).Amount -= amount;
        }

        public void AddProduct(Shop shop, Product product, int amount, float price)
        {
            if (!IsShopInDatabase(shop))
            {
                throw new ShopsException("No such shop in database.");
            }

            _database[_database.IndexOf(shop)].AddProduct(product, amount, price);
        }

        public void DeliverProducts(Shop shop, ReadOnlyCollection<ShopProduct> productList)
        {
            if (!IsShopInDatabase(shop))
            {
                throw new ShopsException("No such shop in database.");
            }

            foreach (ShopProduct newProduct in productList)
            {
                if (shop.IsInCatalog(newProduct.ProductInstance))
                {
                    int newAmount = newProduct.Amount + shop.FindProduct(newProduct).Amount;
                    shop.FindProduct(newProduct).Amount = newAmount;
                }
                else
                {
                    GetShopFromDatabase(shop).AddProduct(newProduct.ProductInstance, newProduct.Amount, newProduct.Price);
                }
            }
        }

        public ShopProduct FindProductWithMinPrice()
        {
            float min = float.MaxValue;
            ShopProduct foundProduct = null;
            foreach (ShopProduct product in from shop in _database
                from product in shop.GetCatalog()
                where product.Price < min
                select product)
            {
                min = product.Price;
                foundProduct = product;
            }

            return foundProduct;
        }

        public ShopProduct FindProductWithMaxPrice()
        {
            float max = float.MinValue;
            ShopProduct foundProduct = null;
            foreach (ShopProduct product in from shop in _database
                from product in shop.GetCatalog()
                where product.Price > max
                select product)
            {
                max = product.Price;
                foundProduct = product;
            }

            return foundProduct;
        }

        public Customer CreateNewCustomer(string name, int balance)
        {
            return new Customer(name, balance);
        }

        private bool IsShopInDatabase(Shop shop)
        {
            return _database.Contains(shop);
        }

        private Shop GetShopFromDatabase(Shop shop)
        {
            if (!IsShopInDatabase(shop))
            {
                throw new ShopsException("No such shop in database.");
            }

            return _database[_database.IndexOf(shop)];
        }
    }
}