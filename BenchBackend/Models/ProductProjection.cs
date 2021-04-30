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
#nullable enable
        public ICollection<Review>? Reviews { get; set; }
        public double? AvgRating { get; set; }
#nullable disable

    }
}
