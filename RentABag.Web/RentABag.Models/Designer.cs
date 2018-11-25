using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace RentABag.Models
{
    public class Designer
    {
        public Designer()
        {
            this.Bags = new HashSet<Bag>();
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<Bag> Bags { get; set; }
    }
}
