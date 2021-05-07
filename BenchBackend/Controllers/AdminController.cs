﻿using BenchBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchBackend.Services;
using Microsoft.Extensions.Logging;

namespace BenchBackend.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IGetOrders _getOrders;
        private readonly IAdminEditProduct _adminEditProduct;
        private readonly IDataSerializer _serializer;

        public AdminController(ILogger<AdminController> logger, IDataSerializer serializer, IGetOrders getOrders, IAdminEditProduct adminEditProduct)
        {
            _logger = logger;
            _serializer = serializer;
            _getOrders = getOrders;
            _adminEditProduct = adminEditProduct;
        }

        /// <summary>
        /// Async Post request to edit a current product
        /// </summary>
        /// <param name="EditedProduct">Class of params to identify product to edit</param>
        /// <returns>Changes to product</returns>
        [HttpPost("/admin/product/edit")]
        public async Task<IActionResult> PostEditedProduct(PostEditProductParameters EditedProduct)
        {
            try
            {
                var newProd = await _adminEditProduct.ExecuteAsync(EditedProduct);
                return StatusCode(200, newProd);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode(500, e.Message);
            }
            
        }

        /// <summary>
        /// Async Get request to get all unfufilled orders
        /// </summary>
        /// <returns>List of all unfufiled orders</returns>
        [HttpGet("/admin/orders/current")]
        public async Task<IActionResult> GetAllCurrentOrders()
        {
            try
            {
                var CurrentOrders = await _getOrders.GetCurrentOrdersAsync();
                return StatusCode(200, CurrentOrders);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("admin/orders/xml")]
        public async Task<IActionResult> OrdersXmlAsync()
        {
            try
            {
                var allOrders = await _getOrders.GetAllOrdersAsync();
                byte[] xml = _serializer.Serialize(allOrders);
                string filename = $"Orders_{DateTime.Now}.xml";

                return File(xml, "text/xml", filename);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }
    }
}
