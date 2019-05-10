using System.Collections.Generic;

namespace Enttites
{
    class ProductList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public ICollection<ProductList> Accessories { get; }

        public ProductList(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
            Accessories = new List<ProductList>();
        }
    }


}