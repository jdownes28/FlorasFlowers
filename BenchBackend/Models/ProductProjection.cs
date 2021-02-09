using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class ProductProjection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public IEnumerable<string> ReviewTitle { get; set; }
        public IEnumerable<string> ReviewContent { get; set; }
        public double AvgRating { get; set; }
    }
}
