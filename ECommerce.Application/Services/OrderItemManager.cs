using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;

        public OrderItemManager(IOrderItemRepository repository)
        {
            _repository = repository;
        }


        public void Add(CreateOrderItemDto createDto)
        {
            throw new NotImplementedException();


        }

        public OrderItemDto Get(Expression<Func<Domain.Entities.OrderItem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<OrderItemDto> GetAll(Expression<Func<Domain.Entities.OrderItem, bool>>? predicate, bool AsNoTracking)
        {
            throw new NotImplementedException();
        }

        public OrderItemDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateOrderItemDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}

