using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom_EF_Core.Models
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }

        // Navigation properties for Cart and Product
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
