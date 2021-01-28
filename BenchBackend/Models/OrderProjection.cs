﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class OrderProjection
    {
        public DateTime OrderPlaced { get; set; }
        public IEnumerable<string> ProductsOrdered { get; set; }
        public IEnumerable<int> Quantity { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string TaskList { get; set; }
    }
}
