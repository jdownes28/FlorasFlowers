using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BenchBackend.Models
{
    [DataContract]
    public class Customer
    {
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

#nullable enable

        [DataMember]
        public string? Address { get; set; }

        public string? Phone { get; set; }

        [DataMember]
        public string? Email { get; set; }

#nullable disable

        public ICollection<Order> Orders { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
