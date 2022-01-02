using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musik_Affär.Models
{
    public class Order
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        public IEnumerable<Product> Products { get; set; }

        [Required]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
