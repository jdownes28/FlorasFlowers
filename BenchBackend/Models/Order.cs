using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderPlaced { get; set; }

        public DateTime? OrderFulfilled { get; set; }

        public string DeliveryAddress { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderContents> OrderContents { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
