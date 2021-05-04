using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    [DataContract(Name = "Product", Namespace = "http://www.flowers.com")]
    public class ProductXml
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
}
