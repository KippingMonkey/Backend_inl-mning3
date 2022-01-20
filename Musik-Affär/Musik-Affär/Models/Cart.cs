using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musik_Affär.Models
{
    public class Cart
    {
        public int ID { get; set; }

        [Required]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
