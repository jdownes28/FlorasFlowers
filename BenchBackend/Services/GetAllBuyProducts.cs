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
        private readonly FlorasContext _context;

        public GetAllBuyProducts(FlorasContext context)
        {
            _context = context;
        }

        public async Task<List<ProductProjection>> ExecuteAsync()
        {

            var products = await _context.Products
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
