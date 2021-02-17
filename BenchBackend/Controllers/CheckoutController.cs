using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Controllers
{
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        [HttpGet("/order")]
        public async Task<Order> PlaceOrder()
        {
            using FlorasContext context = new FlorasContext();

            //Sample List
            List<int> listOfProductId = new List<int>() { 1, 2 };

            Order order = new Order();
            List<OrderContents> listofcontents = new List<OrderContents>();

            order.OrderPlaced = DateTime.Now;
            order.OrderFulfilled = null;

            foreach (var productId in listOfProductId)
            {
                var product = context.Products.First(id => id.Id == productId);
                OrderContents orderContents = new OrderContents()
                {
                    Product = product,
                    PriceAtTimeOfOrder = product.Price,
                    Name = product.Name
                };
                listofcontents.Add(orderContents);
            }

            order.OrderContents = listofcontents;

            return order;

            /*
            var CreateNewOrder = await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            */
        }
    }
}
