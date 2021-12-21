using System.Collections.Generic;

namespace Musik_Affär.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public Brand Brand { get; set; }
        public List<Order> Orders { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
