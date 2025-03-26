using ECommerce.Application.Services;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs;

namespace ECommerce.UI
{
    public class UserUI
    {
        private static AppDbContext context = new AppDbContext();
        private static UserManager userManager = new UserManager(
            new UserRepository(context));


        public static void ShowMenu()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== User  Menu ====");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Update User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. List All Users");
                Console.WriteLine("5. List By Id User");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUser(); break;
                    case "2":
                        UpdateUser(); break;
                    case "3":
                        RemoveUser(); break;
                    case "4":
                        GetAll(); break;
                    case "5":
                        GetById(); break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice."); break;
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

        }


        private static void AddUser()
        {
            Console.Clear();
            Console.WriteLine("Add New Product");

            Console.Write("Enter Username: ");
            string name = Console.ReadLine();

            Console.Write("Enter Pasword: ");
            string password = Console.ReadLine();

            Console.Write("Enter Email adress: ");
            string email = Console.ReadLine();

            var createUserDto = new UserCreateDto
            {
                UserName = name,
                Password = password,
                Email = email
            };

            userManager.Add(createUserDto);

        }

        private static void UpdateUser()
        {
            Console.Write("Enter the user ID to update: ");
            int userId = int.Parse(Console.ReadLine());
            var existingUser = userManager.GetById(userId);
            if (existingUser == null)
            {
                Console.WriteLine("User not found.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }
            Console.Write($"Enter new name (current: {existingUser.UserName}): ");
            string newName = Console.ReadLine();

            Console.Write("Enter Pasword: ");
            string password = Console.ReadLine();

            Console.Write($"Enter new name (current: {existingUser.Email}): ");
            string newEmail = Console.ReadLine();

            var updateUserDto = new UserUpdateDto
            {
                UserName = newName,
                Email = newEmail
            };
            userManager.Update(updateUserDto);

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

        }

        private static void RemoveUser()
        {
            Console.Write("Enter the user ID to remove: ");
            int userId = int.Parse(Console.ReadLine());
            userManager.Remove(userId);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void GetAll()
        {
            var userDtoList = userManager.GetAll(null, true);
            if (userDtoList.Count == 0)
            {
                Console.WriteLine("No categories found.");
            }
            else
            {
                foreach (var user in userDtoList)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.UserName}, Email :{user.Email}");
                }
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void GetById()
        {
            Console.Write("Enter the user ID: ");
            int userId = int.Parse(Console.ReadLine());
            var userDto = userManager.GetById(userId);

            if (userDto == null)
            {
                Console.WriteLine(" User not found.");
            }
            else
            {
                Console.WriteLine($"ID: {userDto.Id}");
                Console.WriteLine($"UserName: {userDto.UserName}");
                Console.WriteLine($"Email:{userDto.Email}");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

        }
    }
}
