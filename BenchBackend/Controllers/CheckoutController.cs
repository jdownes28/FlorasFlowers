using BenchBackend.Data;
using BenchBackend.Models;
using BenchBackend.Queries;
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
        public async Task<Order> PlaceOrderAsync(PlaceOrderParameters placeOrderParameters)
        {
            PlaceOrder placeOrder = new PlaceOrder();
            var OrderStatus = await placeOrder.ExecuteAsync(placeOrderParameters);
            return OrderStatus;
            
        }
    }
}
