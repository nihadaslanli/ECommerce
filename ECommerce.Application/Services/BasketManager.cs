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
    public class BasketManager : IBasketService
    {
        private readonly IBasketRepository _repository;

        public BasketManager(IBasketRepository repository)
        {
            _repository = repository;
        }



        public List<BasketDto> GetAll(Expression<Func<Basket, bool>>? predicate, bool AsNoTracking)
        {
            var baskets = _repository.GetAll(predicate, AsNoTracking);

            var basketDtos = baskets.Select(b => new BasketDto
            {



            }).ToList();

            return basketDtos;
        }

        List<BasketDto> IBasketService.GetAll(Expression<Func<IBasketService, bool>>? predicate, bool AsNoTracking)
        {
            throw new NotImplementedException();
        }

        private readonly List<ProductDto> _basket = new List<ProductDto>();
    }
}

