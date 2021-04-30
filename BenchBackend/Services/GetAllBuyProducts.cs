using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public class GetAllBuyProducts : IGetAllBuyProducts
    {
        public async Task<List<ProductProjection>> ExecuteAsync()
        {
            using FlorasContext context = new FlorasContext();

            var products = await context.Products
                .Include(r => r.Reviews)
                .Where(prod => prod.ProductType.Id == 1)
                .Select(sel => new ProductProjection
                {
                    Id = sel.Id,
                    Name = sel.Name,
                    Price = sel.Price,
                    Reviews = sel.Reviews,
                    AvgRating = sel.Reviews.Select(r => r.Rating).Average()
                }
                )
                .ToListAsync();

            return products;
        }
    }
}
