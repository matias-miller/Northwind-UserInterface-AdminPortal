using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class EmployeeTerritory
    {
        [Key]
        [Required]
        public int EmployeeID { get; set; }

        [Key]
        [Required]
        [MaxLength(20)]
        public string TerritoryID { get; set; }
    }
}