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
            Klassisk,
            Akustisk,
            Elektrisk,
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
        public string Category { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Färg")]
        public string Color { get; set; }

        [Display(Name = "Pris")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Display(Name = "Vikt")]
        public float Weight { get; set; } = 0;

        [Display(Name = "Betyg")]
        public double? Score { get; set; } = 0.0;

        [MaxLength(55)]
        [Display(Name = "Märke")]
        public string Brand { get; set; }

        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Cart> Carts { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
