using BenchBackend.Data;
using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public class AdminProductService : IAdminProductService
    {
        private readonly FlorasContext context;

        public AdminProductService(FlorasContext context)
        {
            this.context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task<string> EditProductAsync(PostEditProductParameters EditedProduct)
        {
            Product UpdatedProduct = context.Products.First(pr => pr.Id == EditedProduct.id);

            UpdatedProduct.Name = EditedProduct.name;
            UpdatedProduct.Price = EditedProduct.price;

            await context.SaveChangesAsync();

            string newProd = context.Products.First(pr => pr.Id == EditedProduct.id).ToString();

            return newProd;
        }
    }
}
