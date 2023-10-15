using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom_EF_Core.Models
{
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Product Title")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public double Price { get; set; }
        [DisplayName("Reference Image")]
        public string ImgUrl { get; set; }
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

    }
}
