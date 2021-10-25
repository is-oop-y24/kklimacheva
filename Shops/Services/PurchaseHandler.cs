using Shops.Tools;

namespace Shops.Services
{
    public class PurchaseHandler
    {
        public static void CustomerPurchaseHandler(Customer customer, ShopProduct product, int amount)
        {
            if (product.Price * amount > customer.Balance)
            {
                throw new BalanceException("Not enough money to buy this product.");
            }

            if (product.Amount < amount)
            {
                throw new AmountException("Not enough amount of a product.");
            }

            customer.Balance -= product.Price * amount;
            customer.AddProductToCart(new CartProduct(product.ProductInstance, amount));
        }

        public static void ChangeAmountAfterPurchase(ShopProduct product, int amount)
        {
            product.Amount -= amount;
        }
    }
}