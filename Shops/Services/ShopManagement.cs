using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void CustomerMakePurchase(Customer customer, Shop shop, ShopProduct product, int amount)
        {
            if (!IsShopInDatabase(shop))
            {
                throw new ShopsException("No such shop in database.");
            }

            if (shop.IsInCatalog(product.ProductInstance))
            {
                throw new ProductExistenceException("No such product in catalog.");
            }

            var handler = new PurchaseHandler();
            handler.CustomerPurchaseHandler(customer, product, amount);
            handler.ChangeAmountAfterPurchase(product, amount);
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

        public Shop FindShopWithCheapestProduct()
        {
            float minPrice = float.MaxValue;
            Shop foundShop = null;
            foreach (Shop shop in _database)
            {
                foreach (ShopProduct product in shop.GetCatalog())
                {
                    if (product.Price < minPrice)
                    {
                        minPrice = product.Price;
                        foundShop = shop;
                    }
                }
            }

            return foundShop;
        }

        public Shop FindShopWithMostExpensiveProduct()
        {
            float maxPrice = float.MinValue;
            Shop foundShop = null;
            foreach (Shop shop in _database)
            {
                foreach (ShopProduct product in shop.GetCatalog())
                {
                    if (product.Price > maxPrice)
                    {
                        maxPrice = product.Price;
                        foundShop = shop;
                    }
                }
            }

            return foundShop;
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