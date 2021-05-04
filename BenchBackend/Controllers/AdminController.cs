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
            GetAllCurrentOrders getAllCurrentOrders = new GetAllCurrentOrders();
            var CurrentOrders = await getAllCurrentOrders.ExecuteAsync();
            return CurrentOrders;
        }

        [HttpGet("admin/orders/xml")]
        public async Task<IActionResult> OrdersXmlAsync()
        {
            // Get all orders as allOrders as a list of orders
            using FlorasContext context = new();
            var allOrders = await context.Orders
                .Include(oc => oc.OrderContents).ThenInclude(p => p.Product).ThenInclude(pt => pt.ProductType)
                .Include(cus => cus.Customer)
                .ToListAsync();

            using MemoryStream stream = new();
            XmlTextWriter xmlWriter = new(stream, Encoding.UTF8);

            // Serialize allOrders to xml
            var serializer = new DataContractSerializer(typeof(IEnumerable<Order>));
            serializer.WriteObject(xmlWriter, allOrders);
            xmlWriter.Flush();
            var filename = $"Orders_{DateTime.Now}.xml";

            return File(stream.ToArray(), "text/xml", filename);
        }
    }
}
