﻿using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public class GetSubscriptions : IGetSubscriptions
    {
        public async Task<List<Product>> ExecuteAsync()
        {
            using FlorasContext context = new FlorasContext();
            var product = await context.Products.Where(p => p.Type == "sub").ToListAsync();
            return product;
        }
    }
}