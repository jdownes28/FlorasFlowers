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
        [HttpGet("/admin/products")]
        public List<Product> GetAllProducts()
        {
            using FlorasContext context = new FlorasContext();
            var AllProducts = context.Products.ToList();
            return AllProducts;
        }

        [HttpPost("/admin/product/edit")]
        public async Task<string> PostEditedProduct(PostEditProductParameters EditedProduct)
        {
            AdminEditProduct adminEditProduct = new AdminEditProduct();
            var newProd = await adminEditProduct.ExecuteAsync(EditedProduct);
            return newProd;
        }


        [HttpGet("/admin/orders/current")]
        public async Task<List<OrderProjection>> GetAllCurrentOrders()
        {
            GetAllCurrentOrders getAllCurrentOrders = new GetAllCurrentOrders();
            var CurrentOrders = await getAllCurrentOrders.ExecuteAsync();
            return CurrentOrders;
        }
    }
}
