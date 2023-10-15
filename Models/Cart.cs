using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom_EF_Core.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerID { get; set; }

        // Navigation property for Customer
        public Customer Customer { get; set; }
        // Navigation property for CartItem
        public ICollection<CartItem> CartItems { get; set; }
    }
}
