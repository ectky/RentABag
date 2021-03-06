﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.Models
{
    public class BagOrder
    {
        public int BagId { get; set; }

        public virtual Bag Bag { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public DateTime GetDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int RentalDays { get; set; }
    }
}
