namespace Musik_Affär.Models
{
    public class CartProductQty
    {
        public int ID { get; set; }
        public int Qty { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }

    }
}
