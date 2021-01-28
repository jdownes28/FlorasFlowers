using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public string PostEditedProduct(PostEditProductParameters EditedProduct)
        {
            using FlorasContext context = new FlorasContext();

            var UpdatedProduct = context.Products.First(pr => pr.Id == EditedProduct.id);

            UpdatedProduct.Name = EditedProduct.name;
            UpdatedProduct.Price = EditedProduct.price;

            context.SaveChanges();

            var newProd = context.Products.First(pr => pr.Id == EditedProduct.id).ToString();

            return newProd;
        }


        [HttpGet("/admin/orders/current")]
        public List<OrderProjection> GetAllCurrentOrders()
        {
            using FlorasContext context = new FlorasContext();

            var CurrentOrders = context.Orders.Include(vf => vf.ProductOrders)
                .Where(order => order.OrderFulfilled == null)
                .Select(select => new OrderProjection
                {
                    OrderPlaced = select.OrderPlaced,
                    Address = select.Customer.Address,
                    Name = $"{select.Customer.FirstName} {select.Customer.LastName}",
                    ProductsOrdered = select.ProductOrders.Select(po => po.Product.Name),
                }).ToList();

            return CurrentOrders;
        }
    }
}
