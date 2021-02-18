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
        [HttpGet("/order")]
        public async Task<Order> PlaceOrder()
        {
            PlaceOrder placeOrder = new PlaceOrder();
            var OrderStatus = await placeOrder.ExecuteAsync();
            return OrderStatus;
        }
    }
}
