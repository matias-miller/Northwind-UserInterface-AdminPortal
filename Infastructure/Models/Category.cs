using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}