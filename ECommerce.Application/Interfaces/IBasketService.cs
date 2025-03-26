using ECommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces
{
    public interface IBasketService
    {
        List<BasketDto> GetAll(Expression<Func<IBasketService, bool>>? predicate, bool AsNoTracking);
    }
}
