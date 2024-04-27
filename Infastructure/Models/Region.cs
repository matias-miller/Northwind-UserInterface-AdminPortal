using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegionID { get; set; }

        [Required]
        [MaxLength(255)]  // Assuming a max length for text, adjust as necessary.
        public string RegionDescription { get; set; }
    }
}