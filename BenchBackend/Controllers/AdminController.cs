using BenchBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchBackend.Services;
using BenchBackend.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;

namespace BenchBackend.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// Async Post request to edit a current product
        /// </summary>
        /// <param name="EditedProduct">Class of params to identify product to edit</param>
        /// <returns>Changes to product</returns>
        [HttpPost("/admin/product/edit")]
        public async Task<string> PostEditedProduct(PostEditProductParameters EditedProduct)
        {
            AdminEditProduct adminEditProduct = new AdminEditProduct();
            var newProd = await adminEditProduct.ExecuteAsync(EditedProduct);
            return newProd;
        }

        /// <summary>
        /// Async Get request to get all unfufilled orders
        /// </summary>
        /// <returns>List of all unfufiled orders</returns>
        [HttpGet("/admin/orders/current")]
        public async Task<List<OrderProjection>> GetAllCurrentOrders()
        {
            GetOrders getAllCurrentOrders = new GetOrders();
            var CurrentOrders = await getAllCurrentOrders.GetCurrentOrdersAsync();
            return CurrentOrders;
        }

        [HttpGet("admin/orders/xml")]
        public async Task<IActionResult> OrdersXmlAsync()
        {
            GetOrders getOrders = new();
            DataSerializer<List<Order>> serializer = new();

            try
            {
                var allOrders = await getOrders.GetAllOrdersAsync();
                byte[] xml = serializer.Serialize(allOrders);

                string filename = $"Orders_{DateTime.Now}.xml";

                return File(xml, "text/xml", filename);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
