using NUnit.Framework;
using Shops.Services;
using Shops.Tools;

namespace Shops.Tests
{
    public class Tests
    {
        private IShopManagement  _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = new ShopManagement();
        }

        [Test]
        public void NotEnoughMoneyForPurchase_ThrowException()
        {
            Assert.Catch<ShopsException>(() =>
            {
                Customer newCustomer = _shopManager.CreateNewCustomer("Taylor Swift", 1400);
                var newShop = new Shop("ITMO.Store", "Kronverkskiy 49");
                var newProduct = new Product("Guitar");
                var newShopProduct = new ShopProduct(newProduct, 20, 1989);
                newShop.AddProduct(newShopProduct);
                _shopManager.CustomerMakePurchase(newCustomer,newShop,newShopProduct,10);
            });
        }
        
        [Test]
        public void GetProductFromDatabase_ProductDoesntExist_ThrowException()
        {
            Assert.Catch<ShopsException>(() =>
            {
                var newProduct = new Product("Coca-Cola");
                _shopManager.RegisterProduct("Pepsi");
                _shopManager.GetProductFromDatabase(newProduct.Id);
            });
        }
        
        [Test]
        public void CustomerBuysProduct_ProductAmountChanges()
        {
            Assert.Catch<ShopsException>(() =>
            {
                Customer newCustomer = _shopManager.CreateNewCustomer("Michael Jordan", 190);
                var newShop = new Shop("Nike", "Red Square");
                var newProduct = new Product("Air Jordan");
                var newShopProduct = new ShopProduct(newProduct, 20, 10);
                int amountBeforePurchase = newShopProduct.Amount;
                newShop.AddProduct(newShopProduct);
                _shopManager.CustomerMakePurchase(newCustomer, newShop, newShopProduct, 5);
                if (amountBeforePurchase != newShopProduct.Amount)
                {
                    Assert.Fail();
                }
            });
        }

        [Test]
        public void ShopReceivesNewProduct_ProductIsInCatalog()
        {
            var newShop = new Shop("Dixy", "Kamennoostrovkiy Ave, 42");
            var newProduct = new Product("Bottle of water");
            var newShopProduct = new ShopProduct(newProduct, 40, 25);
            newShop.AddProduct(newShopProduct);
            Assert.True(newShop.IsInCatalog(newProduct));
        }

        [Test]
        public void BuyMoreProductsThanShopHas_ThrowException()
        {
            Assert.Catch<ShopsException>(() =>
            { 
                Customer newCustomer = _shopManager.CreateNewCustomer("Kate Klimacheva", 1200);
                var newShop = new Shop("Perekrestok", "Kolomyazhskiy 17k1");
                var newProduct = new Product("Orange juice");
                var newShopProduct = new ShopProduct(newProduct, 30, 20);
                newShop.AddProduct(newShopProduct);
                _shopManager.CustomerMakePurchase(newCustomer,newShop,newShopProduct,50);
            });
        }
    }
}