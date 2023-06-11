using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InspiroOrder.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalPayment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
