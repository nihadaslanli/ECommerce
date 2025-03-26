using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderService
    {
        OrderDto GetById(int id);

        OrderDto Get(Expression<Func<Order, bool>> predicate);
        List<OrderDto> GetAll(Expression<Func<Order, bool>>? predicate, bool AsNoTracking);
        void Add(CreateOrderDto createDto);
        void Update(UpdateOrderDto updateDto);
        void Remove(int id);

    }
}
