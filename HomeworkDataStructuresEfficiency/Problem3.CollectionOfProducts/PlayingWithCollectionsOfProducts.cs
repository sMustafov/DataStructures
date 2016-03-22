namespace Problem3.CollectionOfProducts
{
    using System;

    class PlayingWithCollectionsOfProducts
    {
        static void Main()
        {
            var product = new ProductCollection();
            product.Add(1, "Laptop1", "Lenovo", 1000.50);
            product.Add(2, "Laptop2", "Toshiba", 1050.99);
            product.Add(3, "Laptop3", "Acer", 1250.50);
            product.Add(4, "Laptop4", "Asus", 1410.80);
            product.Add(5, "Laptop5", "Apple", 2000.90);
            product.Add(6, "Laptop6", "Lenovo B600", 1610.50);
            product.Add(7, "Laptop7", "Toshiba 4555", 1800.50);
            product.Add(8, "Laptop8", "Acer Bas4", 1900.90);
            product.Add(9, "Laptop9", "Asus Per5", 1950.50);

            Console.WriteLine("Count: " + product.Count);  // 9

            Console.WriteLine(product.FindById(5).Supplier);// Apple

            foreach (var prod in product.FindByPriceRange(1000, 1300))
            {
                foreach (var pr in prod.Value)
                {
                    Console.WriteLine(pr.Supplier);// Lenovo, Toshiba, Acer
                }
            }
            foreach (var prod in product.FindByTitle("Laptop9"))
            {
                Console.WriteLine(prod.Supplier); // Asus Per5
            }
        }
    }
}
