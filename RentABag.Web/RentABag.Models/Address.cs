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

        public virtual ICollection<RentABagUser> Users { get; set; }
    }
}
