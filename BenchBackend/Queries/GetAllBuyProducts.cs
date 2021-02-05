using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public class GetAllBuyProducts : IGetAllBuyProducts
    {
        public async Task<List<ProjectionModel>> ExecuteAsync()
        {
            using FlorasContext context = new FlorasContext();
            var products = await context.Products
                .Include(r => r.Reviews)
                .Where(p => p.Type == "buy")
                .Select(sel => new ProjectionModel
                {
                    Id = sel.Id,
                    Name = sel.Name,
                    Price = sel.Price,
                    ReviewTitle = sel.Reviews.Select(r => r.Title),
                    ReviewContent = sel.Reviews.Select(r => r.Content)
                }).ToListAsync();

            return products;
        }
    }
}
