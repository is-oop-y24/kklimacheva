using System;

namespace Shops.Services
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
            Id = ProductIdGenerator.GetInstance().CreateProductId();
        }

        public int Id { get; }
        public string Name { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Shop)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id);
        }

        private bool Equals(Shop other)
        {
            return Equals(Name, other.Name) && Id == other.Id;
        }
    }
}