using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public class GetReviews : IGetReviews
    {
        public async Task<ICollection<ReviewsProjection>> ExecuteAsync(int id)
        {
            using FlorasContext context = new();

            var reviews = await context.Products
                .Include(r => r.Reviews)
                .Where(product => product.Id == id)
                .Select(sel => new ReviewsProjection
                {
                    AverageRating = sel.Reviews.Select(r => r.Rating).Average(),
                    Reviews = sel.Reviews
                })
                .ToListAsync();

            return reviews;
        }
    }
}
