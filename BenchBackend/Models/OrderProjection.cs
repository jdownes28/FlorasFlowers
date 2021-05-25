using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class OrderProjection
    {
        public int Id { get; set; }
        public string OrderPlaced { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double TotalOrderPrice { get; set; }
        public ICollection<OrderContents> ProductsOrdered { get; set; }

    }
}
