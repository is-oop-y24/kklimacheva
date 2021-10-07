namespace Shops.Services
{
    public class ShopProduct
    {
        public ShopProduct(Product product, int amount, float price)
        {
            ProductInstance = product;
            Amount = amount;
            Price = price;
        }

        public Product ProductInstance { get; }
        public int Amount { get; set; }
        public float Price { get; }
    }
}