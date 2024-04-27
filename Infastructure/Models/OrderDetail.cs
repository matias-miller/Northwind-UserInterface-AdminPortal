using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class OrderDetail
    {
        [Key, Column(Order = 0)]
        [Required]
        public int OrderID { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public int ProductID { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; } = 0;

        [Required]
        public int Quantity { get; set; } = 1;

        [Required]
        [Column(TypeName = "real")]
        public float Discount { get; set; } = 0.0f;

        // Navigation properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}