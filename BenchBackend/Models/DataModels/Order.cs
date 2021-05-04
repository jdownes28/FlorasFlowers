using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    [DataContract(Name = "Order", Namespace = "http://www.flowers.com")]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime OrderPlaced { get; set; }

        [DataMember]
        public DateTime? OrderFulfilled { get; set; }

        [DataMember]
        public string DeliveryAddress { get; set; }

        [DataMember(Name = "CustomerDetails")]
        public Customer Customer { get; set; }

        [DataMember]
        public double TotalOrderPrice { get; set; }

        [DataMember]
        public ICollection<OrderContents> OrderContents { get; set; }
    }
}
