using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderManager(IOrderRepository repository)
        {
            _repository = repository;
        }

        public void Add(CreateOrderDto createDto)
        {
            var order = new Order
            {
                CustomerId = createDto.CustomerId,


            };

        }

        public OrderDto Get(Expression<Func<Order, bool>> predicate)
        {
            var order = _repository.Get(predicate);

            var orderDto = new OrderDto
            {
                Id = order.Id,
                TotalAmount = order.TotalAmount,
                CustomerId = order.CustomerId,




            };
            return orderDto;
        }

        public List<OrderDto> GetAll(Expression<Func<Order, bool>>? predicate, bool AsNoTracking)
        {
            var orders = _repository.GetAll(predicate, AsNoTracking);
            var orderDtoList = new List<OrderDto>();

            foreach (var item in orders)
            {
                orderDtoList.Add(new OrderDto
                {
                    Id = item.Id,
                    CustomerId = item.CustomerId,
                    TotalAmount = item.TotalAmount

                });


            }

            return orderDtoList;
        }

        public OrderDto GetById(int id)
        {
            var order = _repository.GetById(id);
            var orderDto = new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                TotalAmount = order.TotalAmount

            };

            return orderDto;
        }

        public void Remove(int id)
        {
            var existEntity = _repository.GetById(id);
            if (existEntity == null) throw new Exception("Not found");

            _repository.Remove(existEntity);



        }

        public void Update(UpdateOrderDto updateDto)
        {
            var order = new Order
            {
                Id = updateDto.Id,

            };


        }
    }
}

