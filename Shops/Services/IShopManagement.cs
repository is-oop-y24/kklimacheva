using System.Collections.ObjectModel;

namespace Shops.Services
{
    public interface IShopManagement
    {
        Shop AddShop(string name, string address);
        Customer CreateNewCustomer(string name, int balance);
        void CustomerMakePurchase(Customer customer, Shop shop, Product product, int amount);
        void DeliverProducts(Shop shop, ReadOnlyCollection<ShopProduct> productList);
        void AddProduct(Shop shop, Product product, int amount, float price);
        ShopProduct FindProductWithMinPrice();
        ShopProduct FindProductWithMaxPrice();
    }
}