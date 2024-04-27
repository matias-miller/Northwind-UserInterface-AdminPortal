using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        public string CustomerID { get; set; }
        
        public int? EmployeeID { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? RequiredDate { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Freight { get; set; } = 0;

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }
        
        // Navigation properties
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}