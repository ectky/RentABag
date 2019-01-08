using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int BagId { get; set; }

        public virtual Bag Bag { get; set; }
    }
}
