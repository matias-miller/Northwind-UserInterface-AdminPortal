using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Shipper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShipperID { get; set; }

        [Required]
        [MaxLength(255)]  // Assuming a max length for text, adjust as necessary.
        public string CompanyName { get; set; }

        [MaxLength(20)]  // Assuming a max length for phone numbers, adjust as necessary.
        public string Phone { get; set; }
    }
}