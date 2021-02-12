using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchBackend.Queries;

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
    }
}
