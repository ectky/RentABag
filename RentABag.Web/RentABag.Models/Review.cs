using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime ReviewedOn { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public int? BagId { get; set; }

        public virtual Bag Bag { get; set; }

        public int? ShopId { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
