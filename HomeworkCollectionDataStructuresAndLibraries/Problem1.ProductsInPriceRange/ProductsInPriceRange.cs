namespace Problem1.ProductsInPriceRange
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    class ProductsInPriceRange
    {
        static void Main()
        {
            var productsInPriceRange = new OrderedMultiDictionary<double,string>(true);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string productName = input[0];
                double productPrice = double.Parse(input[1]);
                productsInPriceRange.Add(productPrice,productName);
            }

            double[] range = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double minPrice = range[0];
            double maxPrice = range[1];

            var prodList = productsInPriceRange.Range(minPrice, true, maxPrice, true);

            foreach (var prod in prodList)
            {
                string output = String.Format("{0:f2} {1}", prod.Key, prod.Value);
                Console.WriteLine(output);
            }
        }
    }
}
