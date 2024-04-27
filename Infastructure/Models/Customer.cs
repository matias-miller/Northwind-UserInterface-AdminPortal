using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public string CustomerID { get; set; }

        [Required]
        public string CustomerTypeID { get; set; }
    }
}