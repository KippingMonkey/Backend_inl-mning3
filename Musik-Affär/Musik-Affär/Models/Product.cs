using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Musik_Affär.Models;

namespace Musik_Affär.Models
{
    public class Product
    {
        public int ID { get; set; }
        [MaxLength(55)]
        [Display(Name ="Namn")]
        public string Name { get; set; }
        [MaxLength(55)]
        [Display(Name = "Kategori")]
        public string Category { get; set; }
        [MaxLength(25)]
        [Display(Name = "Färg")]
        public string Color { get; set; }
        [Display(Name = "Pris")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Display(Name = "Vikt")]
        public float Weight { get; set; }
        [MaxLength(55)]
        [Display(Name = "Märke")]
        public string BrandName { get; set; } = "Yamaha";
        //[Display(Name = "Märke")]
        public Brand Brand { get; set; }
        public List<Order> Orders { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
