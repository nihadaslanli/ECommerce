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
    public class UserManager : IUserService
    {
        private readonly IUserRepository _reposiotry;

        public UserManager(IUserRepository reposiotry)
        {
            _reposiotry = reposiotry;
        }

        public void Add(UserCreateDto createDto)
        {
            var user = new User();
            {
                user.UserName = createDto.UserName;
                user.Email = createDto.Email;
                user.Password = createDto.Password;
            }

            _reposiotry.Add(user);
        }

        public UserDto Get(Expression<Func<User, bool>> predicate)
        {
            var user = _reposiotry.Get(predicate);
            var userDto = new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
              Password = user.Password
            };
            return userDto;

        }

        public List<UserDto> GetAll(Expression<Func<User, bool>>? predicate, bool AsNoTracking)
        {
            var user = _reposiotry.GetAll(predicate, AsNoTracking);
            var userDtoList = new List<UserDto>();
            foreach (var item in user)
            {
                userDtoList.Add(new UserDto
                {
                    UserName = item.UserName,
                    Email = item.Email,
                    Password = item.Password,
                });

            }

            return userDtoList;
        }

        public UserDto GetById(int id)
        {
            var user = _reposiotry.GetById(id);
            var userDto = new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password
            };

            return userDto;

        }

        public void Remove(int id)
        {
            var existEntity = _reposiotry.GetById(id);
            if (existEntity == null) throw new Exception("Not found");

            _reposiotry.Remove(existEntity);
        }

        public void Update(UserUpdateDto updateDto)
        {
            var user = new User
            {
                UserName = updateDto.UserName,
                Id = updateDto.Id,
                Password = updateDto.Password,
                Email = updateDto.Email

            };
            _reposiotry.Update(user);
        }
    }
}

