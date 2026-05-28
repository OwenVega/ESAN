using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Infrastructure.Repositories;
using UESAN.SHOPPING.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace UESAN.SHOPPING.CORE.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<IEnumerable<ProductListDTO>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var productsDTO = new List<ProductListDTO>();
            foreach (var product in products)
            {
                var productDTO = new ProductListDTO()
                {
                    Id = product.Id,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price ?? 0,
                    Stock = product.Stock ?? 0,
                    CategoryId = product.CategoryId ?? 0,
                    Discount = product.Discount ?? 0
                };
                productsDTO.Add(productDTO);
            }
            return productsDTO;
        }

        public async Task<ProductListDTO> GetProductByID(int id)
        {
            var product = await _productRepository.GetProductById(id);
            var productDTO = new ProductListDTO()
            {
                Id = product.Id,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price ?? 0,
                Stock = product.Stock ?? 0,
                CategoryId = product.CategoryId ?? 0,
                Discount = product.Discount ?? 0
            };
            return productDTO;
        }

        public async Task CreateProduct(ProductCreateDTO productCreateDTO)
        {
            var product = new Product()
            {
                Description = productCreateDTO.Description,
                ImageUrl = productCreateDTO.ImageUrl,
                Price = productCreateDTO.Price,
                Stock = productCreateDTO.Stock,
                CategoryId = productCreateDTO.CategoryId,
                Discount = productCreateDTO.Discount
            };
            await _productRepository.CreateProduct(product);
        }

        public async Task UpdateProduct(ProductUpdateDTO productUpdateDTO)
        {
            var product = new Product()
            {
                Id = productUpdateDTO.Id,
                Description = productUpdateDTO.Description,
                ImageUrl = productUpdateDTO.ImageUrl,
                Price = productUpdateDTO.Price,
                Stock = productUpdateDTO.Stock,
                CategoryId = productUpdateDTO.CategoryId,
                Discount = productUpdateDTO.Discount
            };
            await _productRepository.UpdateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);



        }
    }
}
