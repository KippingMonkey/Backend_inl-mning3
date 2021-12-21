using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;

namespace Musik_Affär.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public List<Product> Products { get; set; }

        [Required]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
