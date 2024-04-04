using System.ComponentModel.DataAnnotations;

namespace FURNITURE_WEB.Models
{
    public class Checkout
    {
        [Key]
        public int Id { get; set; } // Primary key auto-increment column
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string Images { get; set; }
    }
}
