using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class PlaceOrderParameters
    {
        public string email { get; set; }
        public string deliveryAddress { get; set; }
        public int customerId { get; set; }
        public List<int> productsOrderedId { get; set; }
    }
}
