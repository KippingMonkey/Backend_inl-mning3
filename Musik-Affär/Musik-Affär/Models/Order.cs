using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musik_Affär.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> Products { get; set; }

        [Required]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
