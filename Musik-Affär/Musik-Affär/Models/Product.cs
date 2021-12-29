using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Musik_Affär.Models
{
    public class Product
    {
        public enum Manufacturer
        {
            Fender,
            Yamaha,
            PRS,
            HartWood,
            Ibanez,
            Squier,
            Epiphone,
            Gibson
        }

        public enum Style
        {
            Lila,
            Blå,
            Vit,
            Svart,
            Trä,
            Mahogny,
            Sunset,
            Röd
        }

        public enum Type
        {
            Elekriskt,
            Akustisk,
            Dobro,
            Bas,
            Baryton,
        }

        
        public int ID { get; set; }
        [Required]
        [MaxLength(55)]
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [Required]
        [MaxLength(55)]
        [Display(Name = "Kategori")]
        public Type Category { get; set; }
        [Required]
        [MaxLength(25)]
        [Display(Name = "Färg")]
        public Style Color { get; set; }

        [Display(Name = "Pris")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Display(Name = "Vikt")]
        public float Weight { get; set; }

        [MaxLength(55)]
        [Display(Name = "Märke")]
        public Manufacturer Brand { get; set; }

        public List<Order> Orders { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
