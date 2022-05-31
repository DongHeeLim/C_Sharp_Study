using System;
using System.Collections.Generic;

namespace _20220531_delegate_lambda
{
    public delegate void TestDelegate();
    internal class Program
    {
        class Product
        { 
            public string Name { get; set; }
            public int Price { get; set; }
        }

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product(){Name="감자", Price = 500},
                new Product(){Name="사과", Price =700},
                new Product(){Name="고구마", Price = 400}
            };


            products.Sort(SortWithPrice);

            products.Sort(delegate (Product x, Product y)
            {
                return x.Price.CompareTo(y.Price);
            });

            products.Sort((a, b) => a.Price.CompareTo(b.Price));

            products.Sort((a, b) =>
            {
                return a.Price.CompareTo(b.Price);
            });

            foreach (var item in products)
            {
                Console.WriteLine(item.Name + ":" + item.Price);
            }
        }

        private static int SortWithPrice(Product x, Product y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
