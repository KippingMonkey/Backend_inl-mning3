using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musik_Affär.Models
{
    public class Review
    {
        public int ID { get; set; }
        [Display(Name ="Betyg")]
        public byte Grade { get; set; }
        //[NotMapped]
        //[Display(Name = "Product")]
        //public string ProductName { get; set; }
        [Display(Name = "Produkt")]
        public Product Product { get; set; }

        [Required]
        public string UserID { get; set; }
        [Display(Name = "Användare")]
        public IdentityUser User { get; set; }
    }
}
