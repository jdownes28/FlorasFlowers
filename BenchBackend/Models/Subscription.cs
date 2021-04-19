using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
    }
}
