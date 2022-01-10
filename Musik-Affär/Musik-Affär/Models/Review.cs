using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musik_Affär.Models
{
    public class Review
    {
        public int ID { get; set; }
        [Display(Name ="Betyg")]
        public byte Grade { get; set; } = 0;    

        [Display(Name = "Produkt")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        [Display(Name ="Användare")]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
