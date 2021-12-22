using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musik_Affär.Models
{
    public class Product
    {
        public int ID { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Category { get; set; }
        [MaxLength(10)]
        public string Color { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public Brand Brand { get; set; }
        public List<Order> Orders { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
