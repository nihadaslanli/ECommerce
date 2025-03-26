﻿using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore.Context;

namespace ECommerce.Infrastructure.EfCore;

public class OrderItemRepository : EfCoreRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext context) : base(context)
    {

    }
}