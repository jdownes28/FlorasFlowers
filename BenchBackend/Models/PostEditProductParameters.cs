using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class PostEditProductParameters
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
    }
}
