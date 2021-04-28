using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class OrderContents
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string Name { get; set; }
        public double PriceAtTimeOfOrder { get; set; }
    }
}
