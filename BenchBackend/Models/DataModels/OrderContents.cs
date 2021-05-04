using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    [DataContract]
    public class OrderContents
    {
        public int Id { get; set; }

        [DataMember(Name = "ProductDetails")]
        public Product Product { get; set; }

        public string Name { get; set; }

        [DataMember]
        public double PriceAtTimeOfOrder { get; set; }
    }
}
