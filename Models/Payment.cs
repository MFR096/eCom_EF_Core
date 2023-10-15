using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eCom_EF_Core.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderID { get; set; }
        [DisplayName("Payment Date")]
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        // Navigation property for Order
        public Order Order { get; set; }
    }
}
