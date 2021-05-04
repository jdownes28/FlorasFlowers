using BenchBackend.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    [DataContract(Name = "Product", Namespace = "http://www.flowers.com")]
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Price { get; set; }
        public ProductType ProductType { get; set; }
        [DataMember]
        public ICollection<Review> Reviews { get; set; }
    }
}
