using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }

        public Customer Customer { get; set; }

        public Product Product { get; set; }
    }
}
