using BenchBackend.Models;
using BenchBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BenchBackend.Controllers
{
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly IPlaceOrder _placeOrder;

        public CheckoutController(ILogger<CheckoutController> logger, IPlaceOrder placeOrder)
        {
            _logger = logger;
            _placeOrder = placeOrder;
        }

        [HttpPost("/order")]
        public async Task<IActionResult> PlaceOrderAsync(PlaceOrderParameters placeOrderParameters)
        {
            try
            {
                Order OrderStatus = await _placeOrder.ExecuteAsync(placeOrderParameters);
                return StatusCode(200, OrderStatus);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return StatusCode(500, e.Message);
            }
            
            
        }
    }
}
