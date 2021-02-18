using BenchBackend.Data;
using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public class AdminEditProduct : IAdminEditProduct
    {
        public async Task<string> ExecuteAsync(PostEditProductParameters EditedProduct)
        {
            using FlorasContext context = new FlorasContext();

            var UpdatedProduct = context.Products.First(pr => pr.Id == EditedProduct.id);

            UpdatedProduct.Name = EditedProduct.name;
            UpdatedProduct.Price = EditedProduct.price;

            await context.SaveChangesAsync();

            var newProd = context.Products.First(pr => pr.Id == EditedProduct.id).ToString();

            return newProd;
        }
    }
}
