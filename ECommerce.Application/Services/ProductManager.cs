using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Application.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productrepo;
        private readonly List<ProductDto> _basket = new List<ProductDto>();


        public ProductManager(IProductRepository productService, CategoryManager categoryManager)
        {
            _productrepo = productService;
        }

        public void Add(ProductCreateDto createDto)
        {
            var existingProduct = _productrepo.Get(p => p.Name == createDto.Name);
            if (existingProduct != null)
            {
                Console.WriteLine(" Warning: A product with the same name already exists! Product not added.");
                return; 
            }

            Product product = new Product
            {
                Name = createDto.Name,
                Price = createDto.Price,
                CategoryId = createDto.CategoryId,
                Description = createDto.Description,
            };

            _productrepo.Add(product);  
            Console.WriteLine(" Product added successfully!");
        }

        public ProductDto Get(Expression<Func<Product, bool>> predicate)
        {
            var product = _productrepo.Get(predicate);

            var productDto = new ProductDto
            {
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            return productDto;
        }

        public List<ProductDto> GetAll(Expression<Func<Product, bool>>? predicate, bool asNoTracking)
        {

            var products = _productrepo.GetAll(predicate, asNoTracking);
            var productDtoList = new List<ProductDto>();

            foreach (var item in products)
            {
                productDtoList.Add(new ProductDto
                {
                    Id= item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    CategoryId = item.CategoryId,
                });
            }

            return productDtoList;
        }



        public ProductDto GetById(int id)
        {
            var product = _productrepo.GetById(id);

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name
            };

            return productDto;
        }

        public void Remove(int id)
        {
            var existEntity = _productrepo.GetById(id);

            if (existEntity == null) throw new Exception("Not found");

            _productrepo.Remove(existEntity);
        }

        public void Update(ProductUpdateDto updateDto)
        {
            var existingProduct = _productrepo.GetById(updateDto.Id);

            if (existingProduct == null)
            {
                throw new Exception("Product not found.");
            }

            existingProduct.Name = updateDto.Name ?? existingProduct.Name;
            existingProduct.Price = updateDto.Price;
            existingProduct.Description = updateDto.Description ?? existingProduct.Description;
            existingProduct.CategoryId = updateDto.CategoryId;

            _productrepo.Update(existingProduct);
        
        }

        public void AddToBasket(int productId)
        {
            var product = _productrepo.GetById(productId);

            if (product == null)
            {
                Console.WriteLine(" Product not found!");
                return;
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            _basket.Add(productDto);
            Console.WriteLine($"✓ {product.Name} added to basket.");
        }


        public void ShowBasket()
        {
            Console.WriteLine("\n Basket Items:");
            if (_basket.Count == 0)
            {
                Console.WriteLine("Your basket is empty.");
                return;
            }

            foreach (var item in _basket)
            {
                Console.WriteLine($"- {item.Name} | {item.Price}$");
            }
        }
        public void PurchaseBasket()
        {
            if (_basket.Count == 0)
            {
                Console.WriteLine("❌ Your basket is empty. Please add items to your basket before proceeding.");
                return;
            }

            decimal totalAmount = 0;
            foreach (var item in _basket)
            {
                totalAmount += item.Price;
            }

            Console.WriteLine($"Your total basket amount is: {totalAmount}$");
            Console.Write("Do you want to proceed with the purchase? (Yes/No): ");
            string confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "yes")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your purchase has been successfully completed!");


                _basket.Clear();
            }
            else
            {
                Console.WriteLine("Purchase cancelled.");
            }
        }
    }
}


