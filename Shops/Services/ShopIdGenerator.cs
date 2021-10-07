namespace Shops.Services
{
    public class ShopIdGenerator
    {
        private static ShopIdGenerator _instance;
        private ShopIdGenerator() { }
        public int ShopId { get; private set; }
        public static ShopIdGenerator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ShopIdGenerator();
            }

            return _instance;
        }

        public int CreateShopId()
        {
            return _instance.ShopId++;
        }
    }
}