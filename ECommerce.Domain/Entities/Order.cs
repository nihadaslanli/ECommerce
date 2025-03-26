using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public int CustomerId { get; set; }
        public User User { get; set; }
        public StatusType StatusType { get; set; }
    }
    public enum StatusType
    {
        Pending,
        Approved,
        Shipped,
        Delivered
    }
}
