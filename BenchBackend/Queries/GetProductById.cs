using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public class GetProductById : IGetProductById
    {
        public async Task<List<ProductProjection>> ExecuteAsync(int productId)
        {
            using FlorasContext context = new();

            var product = await context.Products
                .Include(p => p.Reviews)
                .Where(p => p.Id == productId)
                .Select(sel => new ProductProjection
                {
                    Id = sel.Id,
                    Name = sel.Name,
                    Price = sel.Price,
                    Reviews = sel.Reviews,
                    AvgRating = sel.Reviews.Select(r => r.Rating).Average()
                })
                .ToListAsync();

            return product;
        }
    }
}
