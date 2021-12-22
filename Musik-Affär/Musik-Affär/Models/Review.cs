using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Musik_Affär.Models
{
    public class Review
    {
        public int ID { get; set; }
        public byte Grade { get; set; }
        public Product Product { get; set; }

        [Required]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
