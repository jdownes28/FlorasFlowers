using BenchBackend.Data;
using BenchBackend.Models;
using BenchBackend.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/products")]
        public async Task<List<ProductProjection>> GetProductsAsync()
        {
            GetAllBuyProducts getAllBuyProducts = new GetAllBuyProducts();
            var products = await getAllBuyProducts.ExecuteAsync();
            return products;
        }

        [HttpGet("/products/filter")]
        public async Task<List<ProductProjection>> GetFilteredProductsAsync([FromQuery] int MinPrice, [FromQuery] int MaxPrice)
        {
            GetFilteredProducts filteredProducts = new GetFilteredProducts();
            var products = await filteredProducts.GetBuyFiltered(MinPrice, MaxPrice);
            return products;
        }

        [HttpGet("/subscriptions")]
        public async Task<List<Product>> GetSubscriptionsAsync()
        {
            GetSubscriptions getSubscriptions = new GetSubscriptions();
            var subscriptions = await getSubscriptions.ExecuteAsync();

            return subscriptions;
        }
    }
}
