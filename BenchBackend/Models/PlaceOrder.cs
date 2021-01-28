using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class PlaceOrder
    {
        public DateTime OrderPlaced { get; set; }
        public string Email { get; set; }
        public string DeliveryAddress { get; set; }
        public int CustomerId { get; set; }
        public List<int> ProductsOrderedId { get; set; }
    }
}
