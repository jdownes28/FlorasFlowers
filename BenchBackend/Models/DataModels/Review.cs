using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    [DataContract]
    public class Review
    {
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Content { get; set; }

        public int Rating { get; set; }

        public Customer Customer { get; set; }

        public Product Product { get; set; }
    }
}
