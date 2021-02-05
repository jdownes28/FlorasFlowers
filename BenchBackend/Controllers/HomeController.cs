using BenchBackend.Data;
using BenchBackend.Models;
using BenchBackend.Queries;
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
        public async Task<List<ProjectionModel>> GetBuy()
        {
            GetAllBuyProducts getAllBuyProducts = new GetAllBuyProducts();
            var products = await getAllBuyProducts.ExecuteAsync();
            return products;
        }

        [HttpGet("/products/filter")]
        public List<ProjectionModel> GetBuyFiltered([FromQuery] int MinPrice, [FromQuery] int MaxPrice)
        {
            GetFilteredProducts filteredProducts = new GetFilteredProducts();
            var products = filteredProducts.GetBuyFiltered(MinPrice, MaxPrice);

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
