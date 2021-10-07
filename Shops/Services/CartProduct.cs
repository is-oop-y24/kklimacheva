namespace Shops.Services
{
    public class CartProduct
    {
        public CartProduct(Product product, int amount)
        {
            ProductInstance = product;
            Amount = amount;
        }

        public Product ProductInstance { get; }
        public int Amount { get; }
    }
}