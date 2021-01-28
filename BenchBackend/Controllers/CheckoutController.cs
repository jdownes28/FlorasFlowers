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
        [HttpPost("/order")]
        public bool PlaceOrder(PlaceOrder placeOrder)
        {
            using FlorasContext context = new FlorasContext();

            Order order = new Order()
            {
                OrderPlaced = placeOrder.OrderPlaced,
                DeliveryAddress = placeOrder.DeliveryAddress,
                Customer = context.Customers.First(cus => cus.Id == placeOrder.CustomerId),
                OrderFulfilled = null,
            };

            ProductOrder productOrder = new ProductOrder()
            {

            };

            var NewOrder = context.Orders.Add(order);

            return true;
        }
    }
}
