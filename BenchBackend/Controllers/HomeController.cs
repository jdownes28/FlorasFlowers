using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BenchBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/getAllBuy")]
        public List<Product> GetProductBuy()
        {
            using FlorasContext context = new FlorasContext();
            var product = context.Products.Where(p => p.Type == "buy").ToList();

            return product;
        }

        [HttpGet("/getAllSub")]
        public List<Product> GetProductSubs()
        {
            using FlorasContext context = new FlorasContext();
            var product = context.Products.Where(p => p.Type == "sub").ToList();

            return product;
        }

        [HttpGet("/lilyReviews")]
        public List<Product> GetLilyReviews()
        {
            using FlorasContext context = new FlorasContext();

            var products = context.Products.Include(r => r.Reviews).ThenInclude(cus => cus.Customer).ToList();

            return products;
        }
    }
}
