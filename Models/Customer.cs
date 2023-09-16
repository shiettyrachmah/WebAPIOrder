using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspiroOrder.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Column(TypeName ="VARCHAR(30)")]

        public string Name { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string Addess { get; set; }
    }
}
