using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musik_Affär.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public List<Product> Products { get; set; }

        //[NotMapped]
        //[Display(Name ="Product")]
        //public string ProductName { get; set; }
        //[NotMapped]
        //[Display(Name = "Price")]
        //public decimal ProductPrice { get; set; }
        //[NotMapped]
        //[Display(Name = "Pcs")]
        //public int Quantity { get; set; }
        //[NotMapped]
        //[Display(Name = "Total")]
        //public decimal Total { get; set; }

        [Required]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
