using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public class GetFilteredProducts : IGetFilteredProducts
    {
        public async Task<List<ProductProjection>> GetBuyFiltered(int MinPrice, int MaxPrice)
        {
            using FlorasContext context = new FlorasContext();

            var products = await context.Products
                .Include(r => r.Reviews)
                .Where(p => p.Type == "buy")
                .Where(p => p.Price >= MinPrice && p.Price <= MaxPrice)
                .Select(sel => new ProductProjection
                {
                    Name = sel.Name,
                    Price = sel.Price,
                    ReviewTitle = sel.Reviews.Select(r => r.Title),
                    ReviewContent = sel.Reviews.Select(r => r.Content),
                    AvgRating = sel.Reviews.Select(r => r.Rating).Average()
                }).ToListAsync();

            return products;
        }
    }
}
