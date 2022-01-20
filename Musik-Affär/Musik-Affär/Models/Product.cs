using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Musik_Affär.Models
{
    
    public class Product
    {
        public enum Manufacturer
        {
            Epiphone,
            Fender,
            Gibson,
            HartWood,
            Ibanez,
            PRS,
            Squier,
            Yamaha,
        }

        public enum Style
        {
            Blå,
            Lila,
            Mahogny,
            Röd,
            Svart,
            Sunset,
            Trä,
            Vit
        }

        public enum Type
        {
            Akustisk,
            Klassisk,
            Baryton,
            Bas,
            Elektrisk
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

        [Display(Name = "SnittBetyg")]
        public double? Score { get; set; } = 0.0;

        [Required]
        [MaxLength(55)]
        [Display(Name = "Märke")]
        public string Brand { get; set; }

        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
