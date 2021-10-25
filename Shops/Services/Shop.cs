using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Shops.Services
{
    public class Shop
    {
        private readonly List<ShopProduct> _catalog = new List<ShopProduct>();
        public Shop(string name, string address)
        {
            Name = name;
            Address = address;
            Id = ShopIdGenerator.GetInstance().CreateShopId();
        }

        public string Name { get; }
        public int Id { get; }
        public string Address { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Shop)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_catalog, Name, Id, Address);
        }

        public ReadOnlyCollection<ShopProduct> GetCatalog()
        {
            return _catalog.AsReadOnly();
        }

        public void AddProduct(ShopProduct newProduct)
        {
            if (IsInCatalog(newProduct.ProductInstance))
            {
                FindProduct(newProduct.ProductInstance).Amount += newProduct.Amount;
            }
            else
            {
                _catalog.Add(newProduct);
            }
        }

        public void AddProduct(Product newProduct, int amount, float price)
        {
            AddProduct(new ShopProduct(newProduct, amount, price));
        }

        public bool IsInCatalog(Product product)
        {
            return FindProduct(product) != null;
        }

        public ShopProduct FindProduct(Product product)
        {
            return _catalog.FirstOrDefault(shopProduct => shopProduct.ProductInstance.Equals(product));
        }

        public ShopProduct FindProduct(ShopProduct product)
        {
            return _catalog.FirstOrDefault(shopProduct => shopProduct.Equals(product));
        }

        private bool Equals(Shop other)
        {
            return Equals(_catalog, other._catalog) && Name == other.Name && Id == other.Id &&
                   Address == other.Address;
        }
    }
}