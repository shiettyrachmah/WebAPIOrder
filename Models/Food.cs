using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspiroOrder.Models
{
    public class Food
    {
        [Key]
        public int FoodID { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public string NameFood { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
    }
}
