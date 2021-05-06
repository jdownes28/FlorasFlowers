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
        private readonly IPlaceOrder _placeOrder;

        public CheckoutController(IPlaceOrder placeOrder)
        {
            _placeOrder = placeOrder;
        }

        [HttpPost("/order")]
        public async Task<Order> PlaceOrderAsync(PlaceOrderParameters placeOrderParameters)
        {
            var OrderStatus = await _placeOrder.ExecuteAsync(placeOrderParameters);
            return OrderStatus;
            
        }
    }
}
