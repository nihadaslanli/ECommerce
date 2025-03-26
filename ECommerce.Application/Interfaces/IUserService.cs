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
    public interface IUserService
    {
        UserDto GetById(int id);

        UserDto Get(Expression<Func<User, bool>> predicate);
        List<UserDto> GetAll(Expression<Func<User, bool>>? predicate, bool AsNoTracking);
        void Add(UserCreateDto createDto);
        void Update(UserUpdateDto updateDto);
        void Remove(int id);
    }
}
