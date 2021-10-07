namespace Shops.Services
{
    public class ProductIdGenerator
    {
        private static ProductIdGenerator _instance;
        private ProductIdGenerator() { }
        public int ProductId { get; private set; } = 100;

        public static ProductIdGenerator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductIdGenerator();
            }

            return _instance;
        }

        public int CreateProductId()
        {
            return _instance.ProductId++;
        }
    }
}