using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
