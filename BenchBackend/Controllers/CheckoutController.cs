using BenchBackend.Models;
using BenchBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
