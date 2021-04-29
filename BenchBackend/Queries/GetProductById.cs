using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public class GetProductById
    {
        /*
        private readonly ILogger<GetProductById> _logger;

        public GetProductById(ILogger<GetProductById> logger)
        {
            _logger = logger;
        }
        */

        public async Task<ProductProjection> ExecuteAsync(int productId)
        {
            using FlorasContext context = new();

            try
            {
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
                .FirstAsync();
                return product;
            }
            catch(Exception e)
            {
                //_logger.LogError(e.ToString());
                return null;
            }

            

            
        }
    }
}
