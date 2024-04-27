using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [MaxLength(50)]
        public string Title { get; set; }
        
        [MaxLength(50)]
        public string TitleOfCourtesy { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? HireDate { get; set; }
        
        [MaxLength(100)]
        public string Address { get; set; }
        
        [MaxLength(50)]
        public string City { get; set; }
        
        [MaxLength(50)]
        public string Region { get; set; }
        
        [MaxLength(20)]
        public string PostalCode { get; set; }
        
        [MaxLength(50)]
        public string Country { get; set; }
        
        [MaxLength(20)]
        public string HomePhone { get; set; }
        
        [MaxLength(10)]
        public string Extension { get; set; }
        
        public byte[] Photo { get; set; }
        
        public string Notes { get; set; }
        
        public int? ReportsTo { get; set; }
        
        [MaxLength(255)]
        public string PhotoPath { get; set; }
    }
}
