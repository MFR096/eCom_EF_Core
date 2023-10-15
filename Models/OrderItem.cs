using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom_EF_Core.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }

        // Navigation properties for Order and Product
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
