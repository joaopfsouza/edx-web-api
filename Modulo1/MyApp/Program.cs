

using Enttites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Insira o json");
            string jsonIn = Console.ReadLine();
            var obj = DeserializeObject<ProductScript>(jsonIn);
            System.Console.WriteLine(obj);
        }


        private static string SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        private static T DeserializeObject<T>(string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }

        private static void ProductListTest()
        {
            ProductList p1 = new ProductList(1001, "P1", 100.1);
            p1.Accessories.Add(new ProductList(1002, "P1A1", 100.2));
            p1.Accessories.Add(new ProductList(1003, "P1A2", 100.3));

            ProductList p2 = new ProductList(2001, "P2", 200.1);
            p2.Accessories.Add(new ProductList(2002, "P2A1", 200.2));
            p2.Accessories.Add(new ProductList(2003, "P2A2", 200.3));

            IList<ProductList> products = new List<ProductList>();

            products.Add(p1);
            products.Add(p2);

            string jsonString = JsonConvert.SerializeObject(products);
            System.Console.WriteLine(jsonString);
        }

        private static void SerializeDeserializeJSON()
        {
            Product product1 = new Product(101, "Red Apple", 1.99);

            //Serialize the product object to Json string
            string jsonString = JsonConvert.SerializeObject(product1);
            Console.WriteLine(jsonString);

            //Deserialize the JSON string back to the product object
            Product product2 = JsonConvert.DeserializeObject<Product>(jsonString);
            Console.WriteLine($"The Product ID is {product2.Id}");
            Console.WriteLine($"The Product Name is {product2.Name}");
            Console.WriteLine($"The Product Price is {product2.Price}");
        }
    }


}
