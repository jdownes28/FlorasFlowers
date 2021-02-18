using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class OrderProjection
    {
        public DateTime OrderPlaced { get; set; }
        public ICollection<OrderContents> ProductsOrdered { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public double TotalPrice { get; set; }
    }
}
