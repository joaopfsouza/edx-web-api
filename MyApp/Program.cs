

using Enttites;
using Newtonsoft.Json;
using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
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
