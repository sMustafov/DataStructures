namespace Problem3.CollectionOfProducts
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class ProductCollection : IProductCollection
    {
        private Dictionary<int, Product> productsById =
            new Dictionary<int, Product>();
        private OrderedMultiDictionary<double, Product> productsByPrice = 
            new OrderedMultiDictionary<double, Product>(true);
        private Dictionary<string, SortedSet<Product>> productsByTitle =
            new Dictionary<string, SortedSet<Product>>();
        private Dictionary<string, SortedSet<Product>> productsByTitleAndPrice =
            new Dictionary<string, SortedSet<Product>>();
        private OrderedDictionary<string, OrderedMultiDictionary<double, Product>> productsByTitleAndPriceRange =
            new OrderedDictionary<string, OrderedMultiDictionary<double, Product>>();
        private Dictionary<string, SortedSet<Product>> productsBySupplierAndPrice =
            new Dictionary<string, SortedSet<Product>>();
        private OrderedDictionary<string, OrderedMultiDictionary<double, Product>> productsBySupplierAndPriceRange =
            new OrderedDictionary<string, OrderedMultiDictionary<double, Product>>();

        public void Add(int id, string title, string supplier, double price)
        {
            Product product = new Product()
            {
                Id = id,
                Title = title,
                Supplier = supplier,
                Price = price
            };

            this.productsById.Add(id, product);

            this.productsByPrice.Add(price,product);

            this.productsByTitle.AppendValueToKey(title, product);

            var bothTitleAndPrice = this.CombineTitleOrSupplierAndPrice(title, price);
            this.productsByTitleAndPrice.AppendValueToKey(bothTitleAndPrice, product);
            if (!this.productsByTitleAndPriceRange.ContainsKey(product.Title))
            {
                this.productsByTitleAndPriceRange.Add(product.Title, new OrderedMultiDictionary<double, Product>(true));
            }
            this.productsByTitleAndPriceRange[product.Title][product.Price].Add(product);

            var bothSupplierAndPrice = this.CombineTitleOrSupplierAndPrice(supplier, price);
            this.productsBySupplierAndPrice.AppendValueToKey(bothSupplierAndPrice, product);
            if (!this.productsBySupplierAndPriceRange.ContainsKey(product.Supplier))
            {
                this.productsBySupplierAndPriceRange.Add(product.Supplier, new OrderedMultiDictionary<double, Product>(true));
            }
            this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Add(product);
        }

        public void Remove(int id)
        {
            var product = productsById[id];

            this.productsByPrice.Remove(product.Price);

            this.productsByTitle.Remove(product.Title);

            var bothTitleAndPrice = this.CombineTitleOrSupplierAndPrice(product.Title, product.Price);
            this.productsByTitleAndPrice.Remove(bothTitleAndPrice);
            this.productsByTitleAndPriceRange[product.Title].Remove(product.Price, product);
            if (this.productsByTitleAndPriceRange[product.Title].Count == 0)
            {
                this.productsByTitleAndPriceRange.Remove(product.Title);
            }

            var bothSupplierAndPrice = this.CombineTitleOrSupplierAndPrice(product.Supplier, product.Price);
            this.productsBySupplierAndPrice.Remove(bothSupplierAndPrice);
            this.productsBySupplierAndPriceRange[product.Supplier].Remove(product.Price, product);
            if (this.productsBySupplierAndPriceRange[product.Supplier].Count == 0)
            {
                this.productsBySupplierAndPriceRange.Remove(product.Supplier);
            }
        }

        public int Count { get { return this.productsByTitle.Count; } }

        public Product FindById(int id)
        {
            Product product;
            var productExists = this.productsById.TryGetValue(id, out product);
            if (product == null)
            {
                throw new KeyNotFoundException("There is no such a product");
            }

            return product;
        }

        public OrderedMultiDictionary<double, Product>.View FindByPriceRange(double minPrice, double maxPrice)
        {
            return this.productsByPrice.Range(minPrice,true, maxPrice,true);
        }

        public IEnumerable<Product> FindByTitle(string title)
        {
            return this.productsByTitle.GetValuesForKey(title);
        }

        public IEnumerable<Product> FindByTitleAndPrice(string title, double price)
        {
            var bothTitleAndPrice = this.CombineTitleOrSupplierAndPrice(title, price);

            return this.productsByTitleAndPrice.GetValuesForKey(bothTitleAndPrice);
        }

        public OrderedMultiDictionary<double, Product>.View FindByTitleAndPriceRange(string title, double minPrice, double maxPrice)
        {
            return this.productsByTitleAndPriceRange[title].Range(minPrice, true, maxPrice, true);
        }

        public IEnumerable<Product> FindBySupplierAndPrice(string supplier, double price)
        {
            var bothSupplierAndPrice = this.CombineTitleOrSupplierAndPrice(supplier, price);

            return this.productsByTitleAndPrice.GetValuesForKey(bothSupplierAndPrice);
        }

        public OrderedMultiDictionary<double,Product>.View FindBySupplierAndPriceRange(string supplier, double minPrice, double maxPrice)
        {
            return this.productsBySupplierAndPriceRange[supplier].Range(minPrice, true, maxPrice, true);
        }

        private string CombineTitleOrSupplierAndPrice(string titleOrSupplier, double price)
        {
            const string separator = "|!|";

            return titleOrSupplier + separator + price;
        }
    }
}