using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public class GetProductById : IGetProductById 
    {
        public async Task<ProductProjection> ExecuteAsync(int productId)
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
            .FirstOrDefaultAsync();

            // Null coalescing operator
            ProductProjection result = product ?? null;

            return result;
            

            

            
        }
    }
}
