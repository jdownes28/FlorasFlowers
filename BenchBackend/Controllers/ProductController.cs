﻿using BenchBackend.Data;
using BenchBackend.Models;
using BenchBackend.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Http Async Get Endpoint for all products
        /// </summary>
        /// <returns>List of all products</returns>
        [HttpGet("/products")]
        public async Task<List<ProductProjection>> GetProductsAsync()
        {
            GetAllBuyProducts getAllBuyProducts = new GetAllBuyProducts();
            var products = await getAllBuyProducts.ExecuteAsync();
            return products;
        }

        /// <summary>
        /// Async Get endpoint for getting a filtered list of products
        /// using a price range
        /// </summary>
        /// <param name="MinPrice">Minimum price as defined by user</param>
        /// <param name="MaxPrice">Maximum price as defined by user</param>
        /// <returns>List of products with attributes in ProductProjection Model</returns>
        [HttpGet("/products/filter")]
        public async Task<List<ProductProjection>> GetFilteredProductsAsync([FromQuery] int MinPrice, [FromQuery] int MaxPrice)
        {
            GetFilteredProducts filteredProducts = new GetFilteredProducts();
            var products = await filteredProducts.ExecuteAsync(MinPrice, MaxPrice);
            return products;
        }

        /// <summary>
        /// Async Get for getting all subscriptions
        /// </summary>
        /// <returns>List of Products where type is subscription</returns>
        [HttpGet("/subscriptions")]
        [Authorize]
        public async Task<List<Product>> GetSubscriptionsAsync()
        {
            GetSubscriptions getSubscriptions = new GetSubscriptions();
            var subscriptions = await getSubscriptions.ExecuteAsync();

            return subscriptions;
        }
    }
}
