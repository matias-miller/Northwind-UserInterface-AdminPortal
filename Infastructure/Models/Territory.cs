using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Territory
    {
        [Key]
        [Required]
        [MaxLength(20)]  // Assuming a max length for text, adjust as necessary.
        public string TerritoryID { get; set; }

        [Required]
        [MaxLength(255)]  // Assuming a max length for text, adjust as necessary.
        public string TerritoryDescription { get; set; }

        [Required]
        public int RegionID { get; set; }

        // Navigation property
        public virtual Region Region { get; set; }
    }
}