using BenchBackend.Data;
using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public class AdminEditProduct : IAdminEditProduct
    {
        private readonly FlorasContext _context;

        public AdminEditProduct(FlorasContext context)
        {
            _context = context;
        }
        public async Task<string> ExecuteAsync(PostEditProductParameters EditedProduct)
        {
            Product UpdatedProduct = _context.Products.First(pr => pr.Id == EditedProduct.id);

            UpdatedProduct.Name = EditedProduct.name;
            UpdatedProduct.Price = EditedProduct.price;

            await _context.SaveChangesAsync();

            string newProd = _context.Products.First(pr => pr.Id == EditedProduct.id).ToString();

            return newProd;
        }
    }
}
