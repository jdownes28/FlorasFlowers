using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BenchBackend.Models.DataModels
{
    [DataContract]
    public class ProductType
    {
        public int Id { get; set; }

        [DataMember]
        public string Type { get; set; }
    }
}
