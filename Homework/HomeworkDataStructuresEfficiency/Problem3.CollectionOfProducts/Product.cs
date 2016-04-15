namespace Problem3.CollectionOfProducts
{
    using System;

    public class Product : IComparable<Product>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Supplier { get; set; }

        public double Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}