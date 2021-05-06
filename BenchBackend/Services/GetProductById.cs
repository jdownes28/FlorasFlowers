using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public class GetProductById : IGetProductById 
    {
        private readonly FlorasContext _context;

        public GetProductById(FlorasContext context)
        {
            _context = context;
        }

        public async Task<ProductProjection> ExecuteAsync(int productId)
        {
            var product = await _context.Products
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
