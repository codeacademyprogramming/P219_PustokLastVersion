using Pustok.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class Order:BaseEntity
    {
        public string AppUserId { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string ContactPhone { get; set; }
        public string Note { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public AppUser AppUser { get; set; }

        public List<OrderBook> OrderBooks { get; set; }
    }
}
