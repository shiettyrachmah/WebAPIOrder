using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InspiroOrder.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public int CustomerID { get; set; }
        [Column(TypeName="decimal(18,4)")]
        public decimal TotalPayment { get; set; }
    }
}
