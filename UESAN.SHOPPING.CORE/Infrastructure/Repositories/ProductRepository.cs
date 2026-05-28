using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using UESAN.SHOPPING.CORE.Core.Interfaces;
namespace UESAN.SHOPPING.CORE.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

    }
}
