using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public double PriceCharged { get; set; }
    }
}
