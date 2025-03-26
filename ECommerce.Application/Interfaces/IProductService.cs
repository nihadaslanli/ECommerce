﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService
    {
        ProductDto GetById(int id);
        ProductDto Get(Expression<Func<Product, bool>> predicate);
        List<ProductDto> GetAll(Expression<Func<Product, bool>>? predicate, bool asNoTracking);
        void Add(ProductCreateDto createDto);
        void Update(ProductUpdateDto updateDto);
        void Remove(int id);

    }
}
