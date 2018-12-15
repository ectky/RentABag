using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.Models
{
    public class BagShop
    {
        public int BagId { get; set; }

        public virtual Bag Bag { get; set; }

        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
