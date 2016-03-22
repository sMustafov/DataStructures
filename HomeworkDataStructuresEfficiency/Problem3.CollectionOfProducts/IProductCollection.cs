namespace Problem3.CollectionOfProducts
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public interface IProductCollection
    {
        void Add(int id,string title, string supplier, double price);

        void Remove(int id);

        int Count { get; }

        Product FindById(int id);

        OrderedMultiDictionary<double, Product>.View FindByPriceRange(double minPrice, double maxPrice);

        IEnumerable<Product> FindByTitle(string title);

        IEnumerable<Product> FindByTitleAndPrice(string title, double price);

        OrderedMultiDictionary<double, Product>.View FindByTitleAndPriceRange(string title, double minPrice, double maxPrice);

        IEnumerable<Product> FindBySupplierAndPrice(string supplier, double price);

        OrderedMultiDictionary<double, Product>.View FindBySupplierAndPriceRange(string supplier, double minPrice, double maxPrice);
    }
}