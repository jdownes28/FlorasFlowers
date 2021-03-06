﻿using BenchBackend.Models;
using BenchBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BenchBackend.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IGetAllBuyProducts getAllBuyProducts;
        private readonly IGetReviews getReviews;
        private readonly IGetProductById getProductById;
        private readonly IGetFilteredProducts getFilteredProducts;
        private readonly IGetSubscriptions getSubscriptions;

        public ProductController(
            ILogger<ProductController> logger, 
            IGetAllBuyProducts getAllBuyProducts, 
            IGetProductById getProductById,
            IGetReviews getReviews,
            IGetFilteredProducts getFilteredProducts,
            IGetSubscriptions getSubscriptions
            )
        {
            _logger = logger;
            this.getAllBuyProducts = getAllBuyProducts;
            this.getProductById = getProductById;
            this.getReviews = getReviews;
            this.getFilteredProducts = getFilteredProducts;
            this.getSubscriptions = getSubscriptions;
        }

        /// <summary>
        /// Http Async Get Endpoint for all products
        /// </summary>
        /// <returns>List of all products</returns>
        [HttpGet("/products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            try
            {
                List<ProductProjection> products = await getAllBuyProducts.ExecuteAsync();
                return StatusCode((int)HttpStatusCode.OK, products);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            
        }

        /// <summary>
        /// Async Get Endpoint for getting product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Singular product</returns>
        [HttpGet("/products/{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                ProductProjection product = await getProductById.ExecuteAsync(id);

                if(product != null)
                {
                    return StatusCode((int)HttpStatusCode.OK, product);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.NotFound, $"Product with Id {id} does not exist");
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Async endpoint for getting reviews for a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Reviews for a product</returns>
        [HttpGet("/products/{id}/reviews")]
        public async Task<IActionResult> GetProductReviewsAsync(int id)
        {
            try
            {
                ICollection<ReviewsProjection> result = await getReviews.ExecuteAsync(id);
                if(result.Count < 1)
                {
                    return StatusCode(404, $"The product of id {id} does not exist");
                }
                return StatusCode((int)HttpStatusCode.OK, result);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Async Get endpoint for getting a filtered list of products
        /// using a price range
        /// </summary>
        /// <param name="MinPrice">Minimum price as defined by user</param>
        /// <param name="MaxPrice">Maximum price as defined by user</param>
        /// <returns>List of products with attributes in ProductProjection Model</returns>
        [HttpGet("/products/filter")]
        public async Task<IActionResult> GetFilteredProductsAsync([FromQuery] int MinPrice, [FromQuery] int MaxPrice)
        {
            try
            {
                List<ProductProjection> products = await getFilteredProducts.ExecuteAsync(MinPrice, MaxPrice);
                return StatusCode((int)HttpStatusCode.OK, products);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            
        }

        /// <summary>
        /// Async Get for getting all subscriptions
        /// </summary>
        /// <returns>List of Products where type is subscription</returns>
        [HttpGet("/subscriptions")]
        [Authorize]
        public async Task<IActionResult> GetSubscriptionsAsync()
        {
            try
            {
                List<Product> subscriptions = await getSubscriptions.ExecuteAsync();
                return StatusCode((int)HttpStatusCode.OK, subscriptions);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            
        }
    }
}
