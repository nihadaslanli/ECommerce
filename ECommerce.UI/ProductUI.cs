using ECommerce.Application.DTOs;
using ECommerce.Application.Services;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.ComponentModel;

namespace ECommerce.UI
{

    
    public class ProductUI
    {
        private static AppDbContext context = new AppDbContext();
        private static ProductManager productManager = new ProductManager(
            new ProductRepository(context),
            new CategoryManager(new CategoryRepository(context))
        );

       

        public static void ShowMenu()
        {

            
            while (true)
            {
               
               
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Clear();
                Console.WriteLine("==== Product Menu ====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. List All Products");
                Console.WriteLine("5. List By Id Category");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct(); 
                        break;
                    case "2":
                        UpdateProduct(); 
                        break;
                    case "3":
                        RemoveProduct(); 
                        break;
                    case "4":
                        GetAll(); 
                        break;
                    case "5":
                        GetById(); 
                        break;
                    case "6":return;
                        
                    default:
                        Console.WriteLine("Invalid choice."); 
                        break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

        }

       
        private static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine(" Add New Product");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product description: ");
            string desc = Console.ReadLine();

            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter category ID: ");
            int categoryId = int.Parse(Console.ReadLine());

            var createProductDto = new ProductCreateDto
            {
                Name = name,
                Price = price,
                CategoryId = categoryId,
                Description = desc
            };

            productManager.Add(createProductDto);

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void UpdateProduct()
        {
            Console.Write("Enter the product ID to update: ");
            int productId = int.Parse(Console.ReadLine());
            var existingProduct = productManager.GetById(productId);
            if (existingProduct == null)
            {
                Console.WriteLine(" Product not found.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }
            Console.Write($"Enter new name (current: {existingProduct.Name}): ");
            string newName = Console.ReadLine();
            Console.Write($"Enter new price (current: {existingProduct.Price}): ");
            decimal newPrice = decimal.Parse(Console.ReadLine());


            Console.Write("Enter new category ID: ");
            int newCategoryId = int.Parse(Console.ReadLine());

            var updateProductDto = new ProductUpdateDto
            {
                Name = newName,
                Price = newPrice,
                CategoryId = newCategoryId
            };

            productManager.Update(updateProductDto);

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();


        }

        private static void RemoveProduct()
        {
            Console.Write("Enter the product ID to remove: ");
            int productId = int.Parse(Console.ReadLine());
            productManager.Remove(productId);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
        private static void GetAll()
        {
            var productDtoList = productManager.GetAll(null, true);
            if (productDtoList.Count == 0)
            {
                Console.WriteLine(" No products found.");
            }
            else
            {

                foreach (var product in productDtoList)
                {
                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}");
                }
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void GetById()
        {
            Console.Write("Enter the product ID: ");
            int productId = int.Parse(Console.ReadLine());
            var productDto = productManager.GetById(productId);


            if (productDto == null)
            {
                Console.WriteLine(" Product not found.");
            }
            else
            {

                Console.WriteLine($"ID: {productDto.Id}");
                Console.WriteLine($"Name: {productDto.Name}");

            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

        }
        


    }
}
