using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class ReviewsProjection
    {
#nullable enable
        public double? AverageRating { get; set; }

        public ICollection<Review>? Reviews { get; set; }
#nullable disable
    }
}
