using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int CustomerId {  get; set; }
        public List<OrderItemDto> Items { get; set; } = new();

    }
    public class CreateOrderDto
    {

        public int CustomerId { get; set; }
        public List<CreateOrderItemDto> Items { get; set; } = new();
    }

    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public List<UpdateOrderItemDto> Items { get; set; } = new();
    }
}


