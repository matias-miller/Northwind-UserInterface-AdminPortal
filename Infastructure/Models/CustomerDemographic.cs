using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infrastructure.Models
{
    public class CustomerDemographic
    {
        [Key]
        [Required]
        public string CustomerTypeID { get; set; }

        public string CustomerDesc { get; set; }
    }
}