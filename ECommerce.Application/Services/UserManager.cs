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
            var existingUser =_reposiotry.Get(u=>u.UserName== createDto.UserName);
            if (existingUser != null)
            {
                Console.WriteLine("Warning : A product with the same name  already exists! User not added!");
                return;
            }
            User user = new User
            {
                UserName = createDto.UserName,
                Email = createDto.Email,
                Password = createDto.Password
            };

            _reposiotry.Add(user);
            Console.WriteLine("User added successfully!");
        }

        public UserDto Get(Expression<Func<User, bool>> predicate)
        {
            var user = _reposiotry.Get(predicate);
            var userDto = new UserDto
            {
                Id = user.Id,
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
                    Id = item.Id,
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
                Id = user.Id,
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
            var existingUser=_reposiotry.GetById(updateDto.Id);
            if (existingUser == null)
            {
                throw new Exception("User not found.");
            }
            existingUser.UserName = updateDto.UserName;
            existingUser.Email = updateDto.Email;
            existingUser.Password = updateDto.Password;

            _reposiotry.Update(existingUser);
            Console.WriteLine("User updated successfully.");

        }
    }
}

