using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public class GetSubscriptions : IGetSubscriptions
    {
        private readonly FlorasContext _context;

        private const int ProductTypeSubscriptionId = 2;

        public GetSubscriptions(FlorasContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> ExecuteAsync()
        {
            var product = await _context.Products.Where(p => p.ProductType.Id == ProductTypeSubscriptionId).ToListAsync();
            return product;
        }
    }
}
