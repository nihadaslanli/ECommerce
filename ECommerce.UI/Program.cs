using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore;
using ECommerce.Infrastructure.EfCore.Context;
using Microsoft.Identity.Client;
using System;

namespace ECommerce.UI
{
    public class Program
    {
         static void Main(string[] args)
        {
            var context = new AppDbContext();
            var orderManager = new OrderManager(
                new OrderRepository(context));
            var basketManager = new BasketManager(
                new BasketRepository(context));
            var productManager = new ProductManager(
            new ProductRepository(context),
            new CategoryManager(new CategoryRepository(context)));
            var categoryManager = new CategoryManager(
                new CategoryRepository(context));


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=== Welcome to ECommerce Console App ===");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the Username:  ");
            string username = Console.ReadLine();
            Console.Write("Enter the Password:  ");
            string password = Console.ReadLine();

            var user = context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null) ;

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong password or Username!");
            }

        
            if (user.UserType == UserType.Admin)
            {

                while (true) 
                {
                    Console.Clear();
                    Console.WriteLine("=== Admin Panel ===");
                    Console.WriteLine("1. Work with Products");
                    Console.WriteLine("2. Work with Categories");
                    Console.WriteLine("3. Work with Users");
                    Console.WriteLine("0. Exit");
                    Console.Write("Select an option: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ProductUI.ShowMenu(); 
                            break;
                        case "2":
                            CategoryUI.ShowMenu();
                            break;
                        case "3":
                            UserUI.ShowMenu();
                            break;
                        case "0":
                            return; 
                        default:
                            Console.WriteLine("Invalid selection.");
                            break;
                    }

                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }



            }


            else
            {
                Console.Clear();
                Console.WriteLine("Hello User");
                Console.WriteLine("1. Get All Products");
                Console.WriteLine("2. Get All Categories");
                Console.WriteLine("3. Get Orders");
                Console.WriteLine("4. Get products in basket");
                Console.WriteLine("0 Back to Main Menu");
                string choice = Console.ReadLine();





                switch (choice)
                {
                    case "1":
                        var products = productManager.GetAll(x => true, true);
                        Console.WriteLine("\nAll Products:");
                        foreach (var product in products)
                        {
                            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                        }

                        Console.Write("Enter the ID of the product to add to basket (or 0 to cancel): ");
                        int selectedProductId = int.Parse(Console.ReadLine());

                        if (selectedProductId != 0)
                        {
                            productManager.AddToBasket(selectedProductId);
                        }
                        break;


                    case "2":
                        var categories = categoryManager.GetAll(x => true, true);
                        Console.WriteLine("All Categories:");
                        foreach (var category in categories)
                        {
                            Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
                        }
                        break;

                    case "3":
                        var orders = orderManager.GetAll(x => true, true);
                        Console.WriteLine("Your Orders:");
                        foreach (var order in orders)
                        {
                            Console.WriteLine($"Order ID: {order.Id}, Total Price: {order.TotalAmount}");
                        }
                        break;

                    case "4":
                        productManager.ShowBasket();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }


        }
    }
}

