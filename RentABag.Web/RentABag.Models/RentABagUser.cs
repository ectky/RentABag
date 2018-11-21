using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace RentABag.Models
{
    public class RentABagUser : IdentityUser
    {
        public RentABagUser()
        {
            this.Orders = new HashSet<Order>();
        }

        public string FullName { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public DateTime Birthday { get; set; }

        public byte[] ProfilePicture { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
