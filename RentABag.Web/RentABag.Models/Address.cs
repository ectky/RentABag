using System;
using System.Collections.Generic;

namespace RentABag.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string ActualAddress { get; set; }

        public string UserId { get; set; }

        public virtual RentABagUser User { get; set; }

        public int? ShopId { get; set; }

        public virtual Shop Shop { get; set; }

        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
