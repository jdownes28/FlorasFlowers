using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BenchBackend.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/products")]
        public List<ProjectionModel> GetBuy()
        {
            using FlorasContext context = new FlorasContext();
            var products = context.Products
                .Include(r => r.Reviews)
                .Where(p => p.Type == "buy")
                .Select(sel => new ProjectionModel
                {
                    Id = sel.Id,
                    Name = sel.Name,
                    Price = sel.Price,
                    ReviewTitle = sel.Reviews.Select(r => r.Title),
                    ReviewContent = sel.Reviews.Select(r => r.Content)
                }).ToList();

            return products;
        }

        [HttpGet("/products/filter")]
        public List<ProjectionModel> GetBuyFiltered([FromQuery] int MinPrice, [FromQuery] int MaxPrice)
        {
            using FlorasContext context = new FlorasContext();

            var minimum = MinPrice;
            var maximum = MaxPrice;

            var products = context.Products
                .Include(r => r.Reviews)
                .Where(p => p.Type == "buy")
                .Where(p => p.Price >= minimum && p.Price <= maximum)
                .Select(sel => new ProjectionModel
                {
                    Name = sel.Name,
                    Price = sel.Price,
                    ReviewTitle = sel.Reviews.Select(r => r.Title),
                    ReviewContent = sel.Reviews.Select(r => r.Content),
                    AvgRating = sel.Reviews.Select(r => r.Rating).Average()
                }).ToList();

            return products;
        }

        [HttpGet("/subscriptions")]
        public List<Product> GetProductSubs()
        {
            using FlorasContext context = new FlorasContext();
            var product = context.Products.Where(p => p.Type == "sub").ToList();

            return product;
        }
    }
}
