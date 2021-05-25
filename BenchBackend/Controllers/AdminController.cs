using BenchBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchBackend.Services;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BenchBackend.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IGetOrders _getOrders;
        private readonly IAdminProductService _adminProductService;
        private readonly IDataSerializer _serializer;

        public AdminController(ILogger<AdminController> logger, IDataSerializer serializer, IGetOrders getOrders, IAdminProductService adminProductService)
        {
            _logger = logger;
            _serializer = serializer;
            _getOrders = getOrders;
            _adminProductService = adminProductService;
        }

        [HttpPost("/admin/product/add")]
        public async Task<IActionResult> AddNewProduct(Product product)
        {
            try
            {
                var result = _adminProductService.AddProductAsync(product);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return null;
            }
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
                string newProd = await _adminProductService.EditProductAsync(EditedProduct);
                return StatusCode((int)HttpStatusCode.OK, newProd);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
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
                List<OrderProjection> CurrentOrders = await _getOrders.GetCurrentOrdersAsync();
                return StatusCode((int)HttpStatusCode.OK, CurrentOrders);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("admin/orders/xml")]
        public async Task<IActionResult> OrdersXmlAsync()
        {
            try
            {
                List<Order> allOrders = await _getOrders.GetAllOrdersAsync();
                byte[] xml = _serializer.Serialize(allOrders);
                string filename = $"Orders_{DateTime.Now}.xml";

                return File(xml, "text/xml", filename);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("admin/order/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                OrderProjection order = await _getOrders.GetOrderById(id);
                if(order == null)
                {
                    return StatusCode((int)HttpStatusCode.NotFound);
                }

                return Ok(order);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
