using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; } = 0;

        public int UnitsInStock { get; set; } = 0;

        public int UnitsOnOrder { get; set; } = 0;

        public int ReorderLevel { get; set; } = 0;

        [Required]
        public string Discontinued { get; set; } = "0";

        // Navigation properties
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        

    }
}