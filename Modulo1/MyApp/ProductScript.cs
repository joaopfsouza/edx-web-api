namespace Enttites
{
    class ProductScript
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        //public double Price { get; set; }

        public ProductScript()
        {

        }
        // public Product(int id, string name, double price)
        // {
        //     Id = id;
        //     Name = name;
        //     Price = price;
        // }

        // public override string ToString(){
        //     return $"{Id}:{Name}:{Price}"
        // }
        public override string ToString(){
            return $"{Name}:";
        }
    }


}