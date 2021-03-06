﻿using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public class GetFilteredProducts : IGetFilteredProducts
    {
        private readonly FlorasContext _context;

        public GetFilteredProducts(FlorasContext context)
        {
            _context = context;
        }

        public async Task<List<ProductProjection>> ExecuteAsync(int MinPrice, int MaxPrice)
        {
            var products = await _context.Products
                .Include(r => r.Reviews)
                .Where(p => p.ProductType.Id == 1)
                .Where(p => p.Price >= MinPrice && p.Price <= MaxPrice)
                .Select(sel => new ProductProjection
                {
                    Name = sel.Name,
                    Price = sel.Price,
                    Reviews = sel.Reviews,
                    AvgRating = sel.Reviews.Select(r => r.Rating).Average()
                }).ToListAsync();

            return products;
        }
    }
}
