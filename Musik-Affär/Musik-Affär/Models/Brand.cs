using System.ComponentModel.DataAnnotations;

namespace Musik_Affär.Models
{
    public class Brand
    {
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
